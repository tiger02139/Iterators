using System;
using System.Collections.Generic;
using System.IO;

namespace Iterators
{
    /// <summary>
    /// Reading a text file, line by line.  Illustration of different ways of doing so.
    /// Four separate concepts here:
    ///     1. How to obtain a TextReader
    ///     2. Managing the lifetime of the TextReader
    ///     3. Iterating over the lines returned by TextReader.ReadLine
    ///     4. Doing something with each of those lines
    /// </summary>
    public static class IterationTextFile_Part1
    {
        /// <summary>
        /// This is the dreaded way of reading file that would make Skeet shudder.
        /// </summary>
        public static void PrintFileGhettoWay()
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
        /// FINALLY, a better way to generalize this AND take care of disposal problem.
        /// 1. The resource is acquired just before you need it.  You're in the context of IDisposable, so you can release the resource at the appropriate time.
        /// 2. If GetEnumerator is called multiple times, each call will result in an independent TextReader being created.
        /// </summary>
        public delegate TextReader Func<TextReader>();

        public static TextReader ProvideReader()
        {
            return new StreamReader(@"..\..\SampleTextFile.txt");
            //return new StreamReader("");
        }

        public static void PrintFile_AwesomeWay()
        {
            Func<TextReader> provider = ProvideReader;

            foreach (string line in ReadStream(provider))
            {
                Console.WriteLine(line);
            }
        }

        public static IEnumerable<string> ReadStream(Func<TextReader> providerOfReader)
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

        public static IEnumerable<string> Where(IEnumerable<string> source,
                                                Predicate<string> predicate)
        {
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException();
            }
            return WhereImpl(source, predicate);
            //foreach (string item in source)
            //{
            //    if (predicate(item))
            //    {
            //        yield return item;
            //    }
            //}
        }
        private static IEnumerable<string> WhereImpl(IEnumerable<string> source,
                                                Predicate<string> predicate)
        {
            foreach (string item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
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

        /// <summary>
        /// The IEnumerable<string> collection that you can iterate over.
        /// But it's specific to textfiles.  It is not general enough for network streams.
        /// </summary>
        /// <param name="filename">The path of a text file</param>
        /// <returns>An IEnumerable collection of lines of a text file</returns>
        public static IEnumerable<string> ReadFile(string filename)
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

        public static void PrintFileUsingLazyIteratorBlockAndPredicate()
        {
            IEnumerable<string> lines = ReadFile(@"..\..\SampleTextFile.txt");
            Predicate<string> predicate = delegate (string line)
                                            {
                                                return line.StartsWith("      And");
                                            };
            //foreach (string line in Where(lines, predicate))
            IEnumerable<string> lineCollection = Where(null, null);
            foreach (string line in Where(null, null))
            {
                Console.WriteLine(line);
            }
        }
    }

}
