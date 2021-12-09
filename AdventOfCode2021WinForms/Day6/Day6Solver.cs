using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021WinForms.Day6
{
    public class Day6Solver : Solver
    {

        public Day6Solver(Action<string, Color?> log) : base(log) { }

        public void Solve(string[] input)
        {
            Part1(input);
            Part2(input);
        }

        private void Part2(string[] input)
        {            
            var fishes = input[0].Split(',').ToList().Select(x => int.Parse(x)).ToArray();
            int days = 256;
            int day = 0;
            int totalFish = 0;
            long[] daysWithFish = new long[9];
            
            for(var i=0; i<fishes.Length; i++)
            {
                daysWithFish[fishes[i]]++;
            }

            while (day < days)
            {
                day++;
                long newFish = daysWithFish[0];
                for(var i=1; i<daysWithFish.Length; i++)
                {
                    daysWithFish[i - 1] = daysWithFish[i];
                }
                daysWithFish[8] = 0;

                daysWithFish[6] += newFish;
                daysWithFish[8] += newFish;
            }

            Log($"Answer2 {daysWithFish.Sum()}\n", null);
        }

        private void Part1(string[] input)
        {            
            var fishes = input[0].Split(',').ToList().Select(x => int.Parse(x)).ToArray();
            int days = 80;
            int day = 0;

            int[][] additionalFishes = new int[days+1][];
            int totalFish = fishes.Length;

            while(day < days)
            {
                day++;

                int fishToAdd = 0;
                for(var i=0; i<fishes.Length; i++)
                {
                    fishes[i]--;
                    if(fishes[i] == -1)
                    {
                        fishes[i] = 6;
                        fishToAdd++;
                        totalFish++;
                    }
                }

                for (var i = 0; i < additionalFishes.Length; i++)
                {
                    if (additionalFishes[i] != null)
                    {
                        for (var j = 0; j < additionalFishes[i].Length; j++)
                        {
                            additionalFishes[i][j]--;
                            if (additionalFishes[i][j] == -1)
                            {
                                additionalFishes[i][j] = 6;
                                fishToAdd++;
                                totalFish++;
                            }
                        }
                    }
                }

                additionalFishes[day] = new int[fishToAdd];
                for (var i = 0; i < additionalFishes[day].Length; i++)
                {
                    additionalFishes[day][i] = 8;
                }
            }


            Log($"Answer1 {totalFish}\n", null);
        }
    }
}
