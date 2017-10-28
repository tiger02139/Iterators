using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterators
{
    public static class IterationTextFile_Part2
    {
        /// <summary>
        /// Here we use a whole type that implements IEnumerable<string>
        /// ReadFile takes in a filename and returns an IEnumerable collection of lines
        /// </summary>
        public static void PrintFileBetterWay()
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
    }
}
