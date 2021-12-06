using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021WinForms.Day5
{
    public class Day5Solver : Solver
    {

        public Day5Solver(Action<string> log) : base(log) { }

        public void Solve(string[] input) {            
            Part1(input);


            // rip
            Part2(input);


        }

        private void Part2(string[] input)
        {
            var coords = new List<Coord>();
            foreach (var item in input)
            {
                var split = item.Split(new string[] { " -> " }, StringSplitOptions.None);
                var a = split[0].Split(',');
                var b = split[1].Split(',');


                coords.Add(new Coord() { X1 = int.Parse(a[0]), Y1 = int.Parse(a[1]), X2 = int.Parse(b[0]), Y2 = int.Parse(b[1]) });

            }

            var maxX1 = coords.Select(x => x.X1).Max();
            var maxX2 = coords.Select(x => x.X2).Max();
            var maxY1 = coords.Select(x => x.Y2).Max();
            var maxY2 = coords.Select(x => x.Y2).Max();

            int[][] grid = new int[Math.Max(maxX1, maxX2) + 2][];
            var maxY = Math.Max(maxY1, maxY2);
            for (var i = 0; i < grid.Length; i++)
            {
                grid[i] = new int[maxY + 2];
            }

            foreach (var coord in coords)
            {
                if (coord.X1 == coord.X2)
                {
                    var bigger = 0;
                    var smaller = 0;
                    if (coord.Y1 > coord.Y2)
                    {
                        bigger = coord.Y1;
                        smaller = coord.Y2;
                    }
                    else
                    {
                        bigger = coord.Y2;
                        smaller = coord.Y1;
                    }
                    for (var i = smaller; i <= bigger; i++)
                    {
                        grid[coord.X1][i]++;
                    }
                }
                else if (coord.Y1 == coord.Y2)
                {
                    var bigger = 0;
                    var smaller = 0;
                    if (coord.X1 > coord.X2)
                    {
                        bigger = coord.X1;
                        smaller = coord.X2;
                    }
                    else
                    {
                        bigger = coord.X2;
                        smaller = coord.X1;
                    }
                    for (var i = smaller; i <= bigger; i++)
                    {
                        grid[i][coord.Y1]++;
                    }
                } else
                {
                    // diagonal

                    bool x2Bigger = coord.X2 > coord.X1;
                    bool y2Bigger = coord.Y2 > coord.Y1;

                    var maxX = Math.Max(coord.X2, coord.X1);
                    var minX = Math.Min(coord.X2, coord.X1);

                    for (var i = 0; i < maxX - minX; i++)
                    {
                        if (x2Bigger && y2Bigger)
                        {
                            grid[coord.X1 + i][coord.Y1 + i]++;
                        }
                        else if (x2Bigger && !y2Bigger)
                        {
                            grid[coord.X1 + i][coord.Y1 - i]++;
                        }
                        else if (!x2Bigger && y2Bigger)
                        {
                            grid[coord.X1 - i][coord.Y1 + i]++;
                        }
                        else
                        {
                            grid[coord.X1 - i][coord.Y1 - i]++;
                        }

                    }
                }
            }

            int count = 0;
            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] > 1)
                    {
                        count++;
                    }
                }
            }


            Log($"Answer2: {count}\n");
        }

        private void Part1(string[] input)
        {
            var coords = new List<Coord>();
            foreach (var item in input)
            {
                var split = item.Split(new string[] { " -> " }, StringSplitOptions.None);
                var a = split[0].Split(',');
                var b = split[1].Split(',');


                coords.Add(new Coord() { X1 = int.Parse(a[0]), Y1 = int.Parse(a[1]), X2 = int.Parse(b[0]), Y2 = int.Parse(b[1]) });

            }

            var maxX1 = coords.Select(x => x.X1).Max();
            var maxX2 = coords.Select(x => x.X2).Max();
            var maxY1 = coords.Select(x => x.Y2).Max();
            var maxY2 = coords.Select(x => x.Y2).Max();

            int[][] grid = new int[Math.Max(maxX1, maxX2) + 1][];
            var maxY = Math.Max(maxY1, maxY2);
            for (var i = 0; i < grid.Length; i++)
            {
                grid[i] = new int[maxY + 1];
            }

            foreach (var coord in coords)
            {
                if (coord.X1 == coord.X2)
                {
                    var bigger = 0;
                    var smaller = 0;
                    if (coord.Y1 > coord.Y2)
                    {
                        bigger = coord.Y1;
                        smaller = coord.Y2;
                    }
                    else
                    {
                        bigger = coord.Y2;
                        smaller = coord.Y1;
                    }
                    for (var i = smaller; i <= bigger; i++)
                    {
                        grid[coord.X1][i]++;
                    }
                }
                else if (coord.Y1 == coord.Y2)
                {
                    var bigger = 0;
                    var smaller = 0;
                    if (coord.X1 > coord.X2)
                    {
                        bigger = coord.X1;
                        smaller = coord.X2;
                    }
                    else
                    {
                        bigger = coord.X2;
                        smaller = coord.X1;
                    }
                    for (var i = smaller; i <= bigger; i++)
                    {
                        grid[i][coord.Y1]++;
                    }
                }
            }

            int count = 0;
            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] > 1)
                    {
                        count++;
                    }
                }
            }


            Log($"Answer1: {count}\n");
        }
    }

    public class Coord
    {
        public int X1 { get; set; }

        public int Y1 { get; set; }

        public int X2 { get; set; }        
        public int Y2 { get; set; }

    }
}
