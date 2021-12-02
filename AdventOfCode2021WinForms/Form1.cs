using AdventOfCode2021WinForms.Day1;
using AdventOfCode2021WinForms.Day2;
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
            this.daysListBox.SelectedIndex = 1;
            this.simpleDataRadioButton.Checked = true;
            //this.fullDataRadioButton.Checked = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //string[] input = LoadInput(this.daysListBox.SelectedIndex+1);
            //Day1Solver d1 = new Day1Solver(Log);
            //d1.Solve(input);

            string[] input2 = LoadInput(this.daysListBox.SelectedIndex + 1);
            Day2Solver d2 = new Day2Solver(Log);
            d2.Solve(input2);
        }        

        public string[] LoadInput(int day)
        {
            string filename = string.Empty;
            if (this.simpleDataRadioButton.Checked)
            {
                filename = $".\\data\\inputday{day}_simple.txt";
            } else {
                filename = $".\\data\\inputday{day}_full.txt";
            }
            var lines = File.ReadLines(filename);
            List<string> data = new List<string>();

            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    data.Add(line);
                }
            }

            return data.ToArray();
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
