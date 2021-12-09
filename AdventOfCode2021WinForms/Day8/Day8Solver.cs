using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021WinForms.Day8
{
    public class Day8Solver : Solver
    {

        public Day8Solver(Action<string, Color?> log) : base(log) { }

        public void Solve(string[] input)
        {
            //Part1(input);

            Part2(input);
        }

        private void Part2(string[] input)
        {
            List<string[]> firstSegments = new List<string[]>();
            List<string[]> secondSegments = new List<string[]>();
            List<string[]> allSegments = new List<string[]>();
            for (var i = 0; i < input.Length; i++)
            {
                var split = input[i].Split(new string[] { " | " }, StringSplitOptions.None);
                firstSegments.Add(split[0].Split(' '));
                secondSegments.Add(split[1].Split(' '));
                var combined = split[0].Split(' ').Concat(split[1].Split(' ')).ToArray();
                allSegments.Add(combined);
            }

            for(var i=0; i<allSegments.Count; i++)
            {
                // :(
            }


            int count = 0;                        
            for (var i = 0; i < firstSegments.Count; i++)
            {
                
                for (var j = 0; j < firstSegments[i].Length; j++)
                {
                    var seg = firstSegments[i][j];
                    DigitDisplay d = new DigitDisplay(Log);

                    for (int k = 0; k < seg.Length; k++)
                    {
                        d.Segments[k] = new Segment(Log) { };
                    }
                }

                for(var j=0; j< secondSegments[i].Length; j++)
                {

                }

            }

            

            Log($"Answer2 {count}\n", null);
        }

        
        private void Part1(string[] input)
        {
            List<string[]> wires = new List<string[]>();
            List<string[]> segments = new List<string[]>();
            for(var i=0; i<input.Length; i++)
            {
                var split = input[i].Split(new string[] { " | " }, StringSplitOptions.None);
                wires.Add(split[0].Split(' '));
                segments.Add(split[1].Split(' '));
            }

            int count = 0;
            for (var i = 0; i < segments.Count; i++)
            {
                for (var j = 0; j < segments[i].Length; j++)
                {
                    if (segments[i][j].Length == 2)
                    {
                        // 1
                        count++;

                    }
                    else if (segments[i][j].Length == 4)
                    {
                        // 4
                        count++;
                    }
                    else if (segments[i][j].Length == 3)
                    {
                        // 7
                        count++;

                    }
                    else if (segments[i][j].Length == 7)
                    {
                        // 8
                        count++;

                    }
                }
                
            }

            Log($"Answer1 {count}\n", null);
        }
    }

    public class DigitDisplay
    {
        public Segment[] Segments = new Segment[7];





        Action<string, Color?> Log = null;
        public DigitDisplay(Action<string, Color?> log)
        {
            Log = log;
        }
    }

    public class Segment
    {
        //  dddd
        // e    a
        // e    a
        //  ffff
        // g    b
        // g    b
        //  cccc

        //  0000
        // 5    1
        // 5    1
        //  6666
        // 4    2
        // 4    2
        //  3333

        public bool IsActive = false;

        public List<char> possibleCharacters = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };

        Action<string, Color?> Log = null;
        public Segment(Action<string, Color?> log)
        {
            Log = log;
        }

    }

}
