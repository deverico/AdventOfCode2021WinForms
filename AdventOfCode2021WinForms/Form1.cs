using AdventOfCode2021WinForms.Day1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventOfCode2021WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //int[] input =
            //{
            //    199,
            //    200,
            //    208,
            //    210,
            //    200,
            //    207,
            //    240,
            //    269,
            //    260,
            //    263
            //};

            int[] input = LoadInput();

            Day1Solver d1 = new Day1Solver(Log);
            d1.Solve(input);
        }        

        public int[] LoadInput()
        {
            string filename = @".\data\input.txt";
            var lines = File.ReadLines(filename);
            List<int> nums = new List<int>();

            foreach (var line in lines)
            {
                if(!string.IsNullOrWhiteSpace(line))
                {
                    nums.Add(int.Parse(line));
                }
            }

            return nums.ToArray();
        }

        public void Log(string message)
        {
            richTextBox1.BeginInvoke(new Action(() =>
            {
                this.richTextBox1.Text += message;
            }));
        }
        
    }
}
