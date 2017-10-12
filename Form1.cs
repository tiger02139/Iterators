using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iterators
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IterationSample collection = new IterationSample();

            foreach (string element in collection)
            {
                Console.WriteLine(element);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IterationTextFile file = new IterationTextFile();

            file.PrintFileGhettoWay();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IterationTextFile file = new IterationTextFile();

            file.PrintFileBetterWay();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IterationTextFile file = new IterationTextFile();

            file.PrintFileMoreGeneral_ButBad();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            IterationTextFile file = new IterationTextFile();

            file.PrintFile_Awesomeway();
        }
    }
}
