using AdventOfCode2021WinForms.Day1;
using AdventOfCode2021WinForms.Day2;
using AdventOfCode2021WinForms.Day3;
using AdventOfCode2021WinForms.Day4;
using AdventOfCode2021WinForms.Day5;
using AdventOfCode2021WinForms.Day6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventOfCode2021WinForms
{
    public partial class Form1 : Form
    {
        private List<Type> SolverClasses = new List<Type>();

        public Form1()
        {           
            InitializeComponent();
            //this.daysListBox.Items.AddRange(Enumerable.Range(1, 25).Select(x => x as object).ToArray());
            LoadClassesAndAddSolvedDays();
            this.daysListBox.SelectedIndex = 5;
            this.simpleDataRadioButton.Checked = true;
            //this.fullDataRadioButton.Checked = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string[] input = LoadInput(int.Parse(this.daysListBox.SelectedItem.ToString()));

            Type toInstantiate = SolverClasses.Where(x => x.Name == $"Day{int.Parse(this.daysListBox.SelectedItem.ToString())}Solver").First();
            object theInstance = Activator.CreateInstance(toInstantiate, new object[] { (Action<string>) Log });
            toInstantiate.GetMethod("Solve").Invoke(theInstance, new object[] { input });
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

        private void LoadClassesAndAddSolvedDays()
        {
            Assembly lib = typeof(Form1).Assembly;
            List<int> solved = new List<int>();
            foreach (Type type in lib.GetTypes())
            {
                if(type.Name.StartsWith("Day") && type.Name.EndsWith("Solver"))
                {
                    SolverClasses.Add(type);
                    

                    var start = type.Name.IndexOf("Day");
                    int idx = int.Parse(type.Name.Substring(start + 3, type.Name.Length - 3 - 6));
                    solved.Add(idx);
                    Console.WriteLine($"{type.Name}");
                }                    
            }

            this.daysListBox.Items.AddRange(solved.OrderBy(x => x).Select(x => x as object).ToArray());

        }
        
    }
}
