using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021WinForms.Day7
{
    public class Day7Solver : Solver
    {

        public Day7Solver(Action<string, Color?> log) : base(log) { }

        public void Solve(string[] input)
        {
            Part1(input);

            Part2(input);
        }

        private void Part2(string[] input)
        {
            var crabmarines = input[0].Split(',').ToList().Select(x => long.Parse(x)).ToArray();

            long min = crabmarines.Min();
            long max = crabmarines.Max();

            if (min != 0)
            {
                Log("Min is not zero.. loop probably broken\n", null);
            }

            long[] cost = new long[max - min];

            for (long i = min; i < max; i++)
            {
                for (long j = 0; j < crabmarines.Length; j++)
                {
                    var sum = Math.Abs(i - crabmarines[j]);
                    cost[i] += sum + ((sum-1)* sum)/2;
                }
            }

            Log($"Answer2 {cost.Min()}\n", null);
            
        }

        private void Part1(string[] input)
        {
            var crabmarines = input[0].Split(',').ToList().Select(x => long.Parse(x)).ToArray();

            long min = crabmarines.Min();
            long max = crabmarines.Max();

            if(min != 0 )
            {
                Log("Min is not zero.. loop probably broken\n", null);
            }

            long[] cost = new long[max - min];

            for(long i=min; i<max; i++)
            {
                for(long j=0; j<crabmarines.Length; j++)
                {
                    cost[i] += Math.Abs(i - crabmarines[j]);
                }
            }

            Log($"Answer1 {cost.Min()}\n", null);
        }
    }
}
