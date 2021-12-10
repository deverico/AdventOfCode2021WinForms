using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021WinForms.Day10
{
    public class Day10Solver : Solver
    {

        public Day10Solver(Action<string, Color?> log) : base(log) { }

        public void Solve(string[] input)
        {
            Part1(input);

            Part2(input);
        }        

        private void Part2(string[] input)
        {
            (char, bool)[][] entries = new (char, bool)[input.Length][];

            var opening = new char[] { '(', '[', '{', '<' };
            var closing = new char[] { ')', ']', '}', '>' };

            List<char> badones = new List<char>();
            List<(int, int, char)> toClose = new List<(int, int, char)>();

            for (var i = 0; i < input.Length; i++)
            {
                entries[i] = new (char, bool)[input[i].Length];

                bool badOneFound = false;
                entries[i][0].Item1 = input[i][0];
                for (var j = 1; j < input[i].Length; j++)
                {
                    entries[i][j].Item1 = input[i][j];

                    if (closing.Contains(input[i][j]))
                    {
                        for (var k = j - 1; k >= 0; k--)
                        {
                            if (entries[i][k].Item2) continue;

                            var c1 = entries[i][k].Item1;
                            var c2 = GetOpeningCharacter(input[i][j]);
                            if (c1 != c2)
                            {
                                //Log($"Found at {i},{j} -> {input[i][j]}, {input[i][j - 1]}\n", null);
                                badones.Add(input[i][j]);
                                badOneFound = true;
                                break;
                            }
                            else
                            {
                                entries[i][k].Item2 = true;
                                entries[i][j].Item2 = true;
                                break;
                            }

                        }
                    }

                    if (badOneFound) break;                  

                }

                if (badOneFound) continue;

                for (var k = input[i].Length - 1; k >= 0; k--)
                {
                    if (!entries[i][k].Item2)
                    {
                        //Log($"Added {i},{k} -> {input[i][k]}\n", null);
                        toClose.Add((i, k, GetClosingCharacter(input[i][k])));
                    }
                }
            }

            long sum = 0;

            // Group by row, order by row, then order by column descending
            var jesus = toClose.GroupBy(a => a.Item1).OrderBy(c => c.Key).Select(d => new { Key = d.Key,  Data = d.OrderByDescending(e => e.Item2) } );

            long[] finalSums = new long[jesus.Count()];
            int count = 0;
            foreach(var jes in jesus)
            {
                foreach (var item in jes.Data)
                {
                    finalSums[count] = DoSum(finalSums[count], item.Item3);
                }

                count++;
            }
            Array.Sort(finalSums);

            Log($"Answer2: {finalSums[finalSums.Length/2]}\n", null);
        }

        private void Part1(string[] input)
        {
            (char, bool)[][] entries = new (char, bool)[input.Length][];

            var opening = new char[] { '(', '[', '{', '<' };
            var closing = new char[] { ')', ']', '}', '>' };

            List<char> badones = new List<char>();
            for (var i = 0; i < input.Length; i++)
            {
                entries[i] = new (char, bool)[input[i].Length];

                bool badOneFound = false;
                entries[i][0].Item1 = input[i][0];
                for (var j = 1; j < input[i].Length; j++)
                {
                    entries[i][j].Item1 = input[i][j];


                    if (closing.Contains(input[i][j]))
                    {
                        for (var k = j - 1; k >= 0; k--)
                        {
                            if (entries[i][k].Item2) continue;

                            var c1 = entries[i][k].Item1;
                            var c2 = GetOpeningCharacter(input[i][j]);
                            if (c1 != c2)
                            {
                                //Log($"Found at {i},{j} -> {input[i][j]}, {input[i][j - 1]}\n", null);
                                badones.Add(input[i][j]);
                                badOneFound = true;
                                break;
                            }
                            else
                            {
                                entries[i][k].Item2 = true;
                                entries[i][j].Item2 = true;
                                break;
                            }

                        }
                    }

                    if (badOneFound) break;
                }
            }

            long sum = 0;
            foreach (var item in badones)
            {
                switch(item)
                {
                    case ')':
                        sum += 3;
                        break;
                    case ']':
                        sum += 57;
                        break;
                    case '}':
                        sum += 1197;
                        break;
                    case '>':
                        sum += 25137;
                        break;
                }
            }

            Log($"Answer1: {sum}\n", null);
        }

        public long DoSum(long sum, char c)
        {
            switch (c)
            {
                case ')':
                    sum = (sum * 5) + 1;
                    break;
                case ']':
                    sum = (sum * 5) + 2;
                    break;
                case '}':
                    sum = (sum * 5) + 3;
                    break;
                case '>':
                    sum = (sum * 5) + 4;
                    break;
            }

            return sum;
        }

        public char GetOpeningCharacter(char c)
        {
            switch (c)
            {
                case ')':
                    return '(';
                case ']':
                    return '[';
                case '}':
                    return '{';
                case '>':
                    return '<';
            }

            return '_';
        }

        public char GetClosingCharacter(char c)
        {
            switch (c)
            {
                case '(':
                    return ')';
                case '[':
                    return ']';
                case '{':
                    return '}';
                case '<':
                    return '>';
            }

            return '!';
        }
    }
}
