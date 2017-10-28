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









    }

}
