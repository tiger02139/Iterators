using System;
using System.Collections.Generic;
using System.IO;

namespace Iterators
{
    public static class IterationTextFile_Part4
    {
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
    }
}
