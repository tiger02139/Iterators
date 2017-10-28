using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterators
{
    public static class IterationTextFile_Part5
    {
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
            foreach (string line in Where(lines, predicate))
            //IEnumerable<string> lineCollection = Where(null, null);
            //foreach (string line in Where(null, null))
            {
                Console.WriteLine(line);
            }
        }
    }
}
