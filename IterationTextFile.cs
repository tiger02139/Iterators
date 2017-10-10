using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Iterators
{
    public class IterationTextFile //: IEnumerable
    {
        public void PrintFile()
        {
            using (StreamReader file = new StreamReader(@"SampleTextFile.txt"))
            {
                string line = file.ReadLine();
                while (true)
                {
                    if (line != null)
                        Console.WriteLine(line);
                    line = file.ReadLine();
                }
            }
        }

        public void PrintFileBetterWay()
        {
            foreach (string line in ReadFile(@"SampleTextFile.txt"))
            {
                Console.WriteLine(line);
            }

            IEnumerator iter = ReadFile(@"SampleTextFile.txt").GetEnumerator();
            iter.MoveNext();
        }

        public IEnumerable<string> ReadFile(string filename)
        {
            using (StreamReader file = new StreamReader(filename))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    yield return line;
                }

            }
        }

        //public IEnumerable<string> ReadLines(TextReader reader)
        //{

        //}

        /*
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
        */
    }
    /*
    public class ReaderIterator : IEnumerator
    {
        public object Current
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
    */
}
