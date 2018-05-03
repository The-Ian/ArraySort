using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace SortingAlgorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const int Size = 5000;
        string[] Names = new string[Size];
        DateTime startTime = DateTime.Now;
        DateTime End;
        TimeSpan Time;


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                int index = 0;
                StreamReader inputFile;
                inputFile = File.OpenText("Names.txt");
                while (index < Names.Length && !inputFile.EndOfStream)
                {
                    Names[index] = inputFile.ReadLine();
                    index++;
                }
                inputFile.Close();
                foreach (string value in Names)
                {
                    resultLB.Items.Add(value);
                }

                End = DateTime.Now;
                Time = End - startTime;
                resultTimeLabel.Text = resultLB.Items.Count.ToString() + " Names added." +
                    " They were loaded in " + Time.Milliseconds + " milliseconds.";
            }
            catch (Exception)
            {
                throw;
            }

        }



        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string txtPath2 = "SortedNames.txt";
                StreamWriter sWriter = new StreamWriter(txtPath2);
                foreach (string name in resultLB.Items)

                {

                    sWriter.WriteLine(name.ToString());

                }

                resultTimeLabel.Text = "File has been exported to a Text file in " + Time.Milliseconds + " milliseconds.";
            }

            catch (Exception ex)
            {
                MessageBox.Show("You have already exported the file.");
            }

        }

        private void sortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int minIndex;
            string minVal;

            try
            {
                for (int Scan = 0; Scan < Names.Length - 1; Scan++)
                {
                    minIndex = Scan;
                    minVal = Names[Scan];

                    for (int index = Scan + 1; index < Names.Length; index++)
                    {
                        if (string.Compare(minVal, Names[index], true) == 1)
                        {
                            minVal = Names[index];
                            minIndex = index;
                        }
                    }
                    Switch(ref Names[minIndex], ref Names[Scan]);
                }

                resultLB.Items.Clear();
                foreach (string name in Names)
                {
                    resultLB.Items.Add(name);
                }

                resultTimeLabel.Text = resultLB.Items.Count.ToString() + " Names sorted in alphabetical order." +
                     " They were loaded in " + Time.Seconds + " seconds.";

            }
            catch (Exception ex)
            {
                 MessageBox.Show("You need to retrieve the values first."); 
            }

        }
        private void Switch(ref string one, ref string two)
        {
            string tempVal = one;
            one = two;
            two = tempVal;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}

