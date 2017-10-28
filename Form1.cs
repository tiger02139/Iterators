using System;
using System.Windows.Forms;

namespace Iterators
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void oldSchool_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Iteration using old school implementation:");
            SampleCollection_OldSchool collection = new SampleCollection_OldSchool();
            foreach (string element in collection)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("Iteration using yield return implementation of state machine:");
            SampleCollection_UsingYield newCollection = new SampleCollection_UsingYield();
            foreach (string element in newCollection)
            {
                Console.WriteLine(element);
            }
        }

        private void iterateGhettoWay_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Iteration through file, *without* using IEnumerable interface");
            IterationTextFile_Part1.PrintFileGhettoWay();
        }

        private void iterateFileSlightlyBetter_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Iteration through file, using IEnumerable collection that you can iterate over.");
            Console.WriteLine("The collection function takes in text file.");
            IterationTextFile_Part2.PrintFileBetterWay();
        }

        private void iterateStream_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Iteration through file, using IEnumerable collection that you can iterate over.");
            Console.WriteLine("The collection function takes in a stream and is more general.");
            Console.WriteLine("However, it has disposable difficulties.");
            IterationTextFile_Part3.PrintFileMoreGeneral_ButBad();
        }

        private void iterate_SomethingWrongHappens_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Disposable difficulties.");
            IterationTextFile_Part3.PrintFile_SomethingWrongHappens();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IterationTextFile_Part3.PrintFile_SeeHowSomethingWrongHappens();

        }


        private void awesomeFileIterator_Click(object sender, EventArgs e)
        {
            IterationTextFile_Part4.PrintFile_AwesomeWay();
        }

        private void iteratorForeshadowLINQWhere_Click(object sender, EventArgs e)
        {
            IterationTextFile_Part5.PrintFileUsingLazyIteratorBlockAndPredicate();
        }
    }
}
