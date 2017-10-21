﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Iterators
{
    /// <summary>
    /// Reading a text file, line by line.  Illustration of different ways of doing so.
    /// Four separate concepts here:
    /// 1. How to obtain a TextReader
    /// 2. Managing the lifetime of the TextReader
    /// 3. Iterating over the lines returned by TextReader.ReadLine
    /// 4. Doing something with each of those lines
    /// </summary>
    public class IterationTextFile
    {
        /// <summary>
        /// This is the dreaded way of reading file that Jon Skeet hates
        /// </summary>
        public void PrintFileGhettoWay()
        {
            using (TextReader file = File.OpenText(@"..\..\SampleTextFile.txt"))
            {
                string line = file.ReadLine();
                while (line != null)
                {
                    if (line != null)
                        Console.WriteLine(line);
                    line = file.ReadLine();
                }
            }
        }

        /// <summary>
        /// Here we use a whole type implementing IEnumerable<string>
        /// </summary>
        public void PrintFileBetterWay()
        {
            foreach (string line in ReadFile(@"..\..\SampleTextFile.txt"))
            {
                Console.WriteLine(line);
            }
        }

        /// <summary>
        /// The IEnumerable<string> collection that you can iterate over.
        /// But it's specific to textfiles.  It is not general enough for network streams.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public IEnumerable<string> ReadFile(string filename)
        {
            using (TextReader file = File.OpenText(filename))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        /// <summary>
        /// See p. 175 of Skeet for long reasons why this is a bad idea.
        /// Discusses inability to dispose if something goes wrong before call to MoveNext.
        /// The caller takes ownership of the reader so it has responsibility to clean it up.
        /// HOWEVER, if something happens before the first call to MoveNext(), the code will
        /// stop running, and you won't have a chance to clean it up.
        /// ALSO, if you call GetEnumerator() twice, both iterators will be tied to the same
        /// reader.
        /// </summary>
        public void PrintFileMoreGeneral_ButBad()
        {
            using (StreamReader reader = new StreamReader(@"..\..\SampleTextFile.txt"))
            //using (StreamReader reader = new StreamReader(@""))
            {
                foreach (string line in ReadStream(reader))
                {
                    Console.WriteLine(line);
                }
            }
            //StreamReader reader = new StreamReader(@"..\..\SampleTextFile.txt");
            //try
            //{
            //    foreach (string line in ReadStream(reader))
            //    {
            //        Console.WriteLine(line);
            //    }
            //}
            //catch (Exception e) 
            //{
            //    Console.WriteLine(e.Message);
            //}
            //finally
            //{
            //    reader.Close();
            //    reader.Dispose();
            //}
        }

        public IEnumerable<string> ReadStream(TextReader reader)
        {
            string line;


            while ((line = reader.ReadLine()) != null)
            {
                throw new Exception();
                yield return line;
            }
        }


        /// <summary>
        /// FINALLY, a better way to generalize this AND take care of disposal problem.
        /// 1. The resource is acquired just before you need it.  You're in the context of IDisposable, so you can release the resource at the appropriate time.
        /// 2. If GetEnumerator is called multiple times, each call will result in an independent TextReader being created.
        /// </summary>
        public delegate TextReader Func<TextReader>();

        public TextReader ProvideReader()
        {
            return new StreamReader(@"..\..\SampleTextFile.txt");
            //return new StreamReader("");
        }

        public void PrintFile_AwesomeWay()
        {
            Func<TextReader> provider = ProvideReader;

            foreach (string line in ReadStream(provider))
            {
                Console.WriteLine(line);
            }
        }

        public IEnumerable<string> ReadStream(Func<TextReader> providerOfReader)
        {
            using (TextReader reader = providerOfReader())
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        /// <summary>
        /// p. 176 Print File lazily using iterator block and predicate
        /// </summary>
        public static IEnumerable<T> Where<T>(IEnumerable<T> source,
                                                Predicate<T> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException();
            }
            return WhereImpl(source, predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        private static IEnumerable<T> WhereImpl<T>(IEnumerable<T> source,
                                                Predicate<T> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public void PrintFileUsingLazyIteratorBlockAndPredicate()
        {
            IEnumerable<string> lines = ReadFile(@"..\..\SampleTextFile.txt");
            Predicate<string> predicate = delegate (string line)
                                            {
                                                return line.StartsWith("      And");
                                            };
            foreach (string line in Where(lines, predicate))
            {
                Console.WriteLine(line);
            }
        }
    }

}
