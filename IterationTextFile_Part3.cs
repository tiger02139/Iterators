using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterators
{
    public static class IterationTextFile_Part3
    {
        /// <summary>
        /// A more general implementation of a Reader.
        /// See p. 175 of Skeet for long reasons why this particular implementation is a bad idea.
        /// Discusses inability to dispose if something goes wrong before call to MoveNext.
        /// The caller takes ownership of the reader so it has responsibility to clean it up.
        /// HOWEVER, if something happens before the first call to MoveNext(), the code will
        /// stop running, and you won't have a chance to clean it up.
        /// ALSO, if you call GetEnumerator() twice, both iterators will be tied to the same
        /// reader.
        /// </summary>
        public static void PrintFileMoreGeneral_ButBad()
        {
            using (StreamReader reader = new StreamReader(@"..\..\SampleTextFile.txt"))
            {
                foreach (string line in ReadStream(reader))
                {
                    Console.WriteLine(line);
                }
            }
        }

        public static IEnumerable<string> ReadStream(TextReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException();
            }

            string line;

            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }

        public static void PrintFile_SomethingWrongHappens()
        {
            using (StreamReader reader = new StreamReader(@"..\..\SampleTextFile.txt"))
            {
                // In the following line, code in ReadStream does not run.
                // No call to MoveNext has been called yet due to deferred execution.
                // Since there no call to MoveNext, ReadStream will now throw ArgumentNullException.
                IEnumerable<string> collection = ReadStream(null);

                // Here is where MoveNext is called
                foreach (string line in collection)
                {
                    Console.WriteLine(line);
                }
            }
        }

        public static void PrintFile_SeeHowSomethingWrongHappens()
        {


            StreamReader reader = new StreamReader(@"..\..\SampleTextFile.txt");
            try
            {
                IEnumerable<string> collection = ReadStream(null);

                foreach (string line in collection)
                {
                    Console.WriteLine(line);
                }
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                reader.Close();
                reader.Dispose();
            }    

        }

    }
}
