using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021WinForms.Day9
{
    public class Day9Solver : Solver
    {

        public Day9Solver(Action<string, Color?> log) : base(log) { }

        public void Solve(string[] input)
        {
            int[][] inputAsInts = new int[input.Length][];
            for (var i = 0; i < input.Length; i++)
            {
                inputAsInts[i] = new int[input[i].Length];
                for (var j = 0; j < input[i].Length; j++)
                {
                    inputAsInts[i][j] = int.Parse(input[i][j].ToString());
                }
            }

            
            //Part1(inputAsInts);
            Part2(inputAsInts);
        }

        private void Part2(int[][] input)
        {
            List<(int, int, int)> lowest = new List<(int, int, int)>();

            (int, bool)[][] grid = new (int, bool)[input.Length][];

            for (var i = 0; i < input.Length; i++)
            {
                grid[i] = new (int, bool)[input[i].Length];
                for (var j = 0; j < input[i].Length; j++)
                {
                    int toCheck = input[i][j];
                    
                    grid[i][j] = (toCheck, false); 

                    var up = i - 1 >= 0 ? input[i - 1][j] : 10;
                    var right = j + 1 < input[i].Length ? input[i][j + 1] : 10;
                    var down = i + 1 < input.Length ? input[i + 1][j] : 10;
                    var left = j - 1 >= 0 ? input[i][j - 1] : 10;
                    if (toCheck < up && toCheck < right && toCheck < down && toCheck < left)
                    {
                        lowest.Add((toCheck, i, j));
                    }
                }
            }

            List<int> areas = new List<int>();
            List<(int, int, int)> areasWithLocation = new List<(int, int, int)>();
            foreach (var low in lowest)
            {
                Log($"searching {low.Item1}, at {low.Item2}, {low.Item3}\n", null);
                int count = 0;
                var area = GetArea(low, grid, ref count);
                areas.Add(count);
                areasWithLocation.Add((count, low.Item2, low.Item3));
                Log($"finished searching {low.Item1}, at {low.Item2}, {low.Item3}\n", null);
            }


            // time to bring some colour
            for(var i=0; i<grid.Length; i++)
            {
                Log($"\n{i:D4} ", null);
                for(var j=0; j<grid[i].Length; j++)
                {
                    (int val, bool wasFound) cell = grid[i][j];

                    var isLowest = lowest.Select(x => (x.Item2, x.Item3)).Contains((i, j));

                    if (isLowest)
                    {
                        Log($"{cell.val}", Color.Red);
                    } else if(cell.wasFound )
                    {
                        Log($"{cell.val}", Color.Orange);
                    } else
                    {
                        Log($"{cell.val}", null);
                    }
                }
            }
            Log("\n", null);
            Log($"Lows: {string.Join(", ", areas.Select(x => x.ToString()).ToArray())}\n", null);
            Log($"Low locations: {string.Join("", areasWithLocation.OrderByDescending(x => x.Item1).Take(3).Select(x => x.Item1.ToString() + $" at {x.Item2}, {x.Item3}\n").ToArray())}\n", null);
            Log($"Top 3 lows: {string.Join(", ", areas.OrderByDescending(x => x).Take(3).Select(x => x.ToString()).ToArray())}\n", null);
            Log($"Answer2: {areas.OrderByDescending(x => x).Take(3).Aggregate((a, b) => a * b)}\n", null);
        }

        private int GetArea((int, int, int) low, (int,bool)[][] input, ref int count)
        {
            GoDirection(low, Direction.Up, input, ref count);
            GoDirection(low, Direction.Right, input, ref count);
            GoDirection(low, Direction.Down, input, ref count);
            GoDirection(low, Direction.Left, input, ref count);

            return count;
        }

        public void GoDirection((int val, int i, int j) low, Direction d, (int val, bool covered)[][] input, ref int count)
        {
            switch(d)
            {
                case Direction.Up:
                    var up = low.i - 1 >= 0 ? input[low.i - 1][low.j].val : 10;
                    if (up < 9)// && up == low.val)
                    {
                        if (!input[low.i - 1][low.j].covered)
                        {
                            input[low.i - 1][low.j].covered = true;
                            count++;
                            Log($"UP: from {low.val}, found: { input[low.i - 1][low.j].val}\n", null);
                            GetArea((up, low.i - 1, low.j), input, ref count);
                            
                        }
                    }
                    break;
                case Direction.Right:
                    var right = low.j + 1 < input[low.i].Length ? input[low.i][low.j + 1].val : 10;                    
                    if (right < 9)// && right - 1 == low.val)
                    {
                        if (!input[low.i][low.j + 1].covered)
                        {
                            input[low.i][low.j + 1].covered = true;
                            count++;
                            Log($"RIGHT: from {low.val}, found: { input[low.i][low.j + 1].val}\n", null);
                            GetArea((right, low.i, low.j + 1), input, ref count);
                        }
                    }
                    break;
                case Direction.Down:
                    var down = low.i + 1 < input.Length ? input[low.i + 1][low.j].val : 10;                        
                    if (down < 9)// && down - 1 == low.val)
                    {                        
                        if (!input[low.i + 1][low.j].covered)
                        {
                            input[low.i + 1][low.j].covered = true;
                            count++;
                            Log($"DOWN: from {low.val}, found: { input[low.i + 1][low.j].val}\n", null);
                            GetArea((down, low.i + 1, low.j), input, ref count);
                        }
                    }
                    break;
                case Direction.Left:                      
                    var left = low.j - 1 >= 0 ? input[low.i][low.j - 1].val : 10;                    
                    if (left < 9)// && left - 1 == low.val)
                    {
                        if (!input[low.i][low.j - 1].covered)
                        {
                            input[low.i][low.j - 1].covered = true;
                            count++;
                            Log($"LEFT: from {low.val}, found: { input[low.i][low.j - 1].val}\n", null);
                            GetArea((left, low.i, low.j - 1), input, ref count);
                        }
                    }
                    break;
            }
        }

        public enum Direction {
            Up,
            Right,
            Down,
            Left
        }

        private void Part1(int[][] input)
        {
            List<int> lowest = new List<int>();
            
            for(var i=0; i<input.Length; i++)
            {
                for(var j=0; j<input[i].Length; j++)
                {
                    int toCheck = input[i][j];

                    var up = i - 1 >= 0 ? input[i-1][j] : 10;
                    var right = j + 1 < input[i].Length ? input[i][j+1] : 10;
                    var down = i + 1 < input.Length ? input[i+1][j] : 10;
                    var left = j - 1 >= 0 ? input[i][j-1] : 10;
                    if(toCheck < up && toCheck < right && toCheck < down && toCheck < left)
                    {
                        lowest.Add(toCheck);
                    }                    
                }
            }

            Log($"Answer1: {lowest.Sum() + lowest.Count()}\n", null);
        }
    }

}
