using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021WinForms.Day13
{
    public class Day13Solver : Solver
    {

        public Day13Solver(Action<string, Color?> log) : base(log) { }

        public void Solve(string[] input)
        {
            Part1(input);
            Part2(input);
        }


        private void Part2(string[] input)
        {
            int paperSizeX = 0;
            int paperSizeY = 0;
            int length = "fold along ".Length;
            List<(FoldDirection, int)> folds = new List<(FoldDirection, int)>();
            List<Mark> marks = new List<Mark>();

            foreach (var item in input)
            {
                if (item.StartsWith("fold"))
                {
                    var split = item.Substring(length, item.Length - length).Split('=');
                    folds.Add(((FoldDirection)Enum.Parse(typeof(FoldDirection), split[0].ToUpper()), int.Parse(split[1])));
                }
                else
                {
                    var split = item.Split(',');
                    marks.Add(new Mark() { X = int.Parse(split[0]), Y = int.Parse(split[1]) });

                    if (int.Parse(split[0]) > paperSizeX)
                    {
                        paperSizeX = int.Parse(split[0]);
                    }

                    if (int.Parse(split[1]) > paperSizeY)
                    {
                        paperSizeY = int.Parse(split[1]);
                    }
                }
            }

            foreach ((FoldDirection Direction, int Amount) fold in folds)
            {
                if (fold.Direction == FoldDirection.X)
                {
                    marks.Where(m => m.X >= fold.Amount).ToList().ForEach(m => m.X = fold.Amount - (m.X - fold.Amount));
                    paperSizeX = fold.Amount - 1;
                }
                else
                {
                    marks.Where(m => m.Y >= fold.Amount).ToList().ForEach(m => m.Y = fold.Amount - (m.Y - fold.Amount));
                    paperSizeY = fold.Amount - 1;
                }
            }

            List<Mark> result = new List<Mark>();
            result.AddRange(marks.GroupBy(m => new { m.X, m.Y }).SelectMany(g => g).Distinct(new MarkComparer()).ToList());


            Log($"Answer2: :)\n", null);
            int count = 0;
            for (var i = 0; i <= paperSizeY; i++)
            {
                for (var j = 0; j <= paperSizeX; j++)
                {
                    if (marks.Any(m => m.Y == i && m.X == j))
                    {
                        Log($"#", null);
                        count++;

                    }
                    else
                    {
                        Log($".", null);
                    }

                }

                Log($"\n", null);
            }
            

        }
    
        private void Part1(string[] input)
        {
            int paperSizeX = 0;
            int paperSizeY = 0;
            int length = "fold along ".Length;
            List<(FoldDirection, int)> folds = new List<(FoldDirection, int)>();
            List<Mark> marks = new List<Mark>();

            foreach (var item in input)
            {
                if(item.StartsWith("fold"))
                {
                    var split = item.Substring(length, item.Length - length).Split('=');
                    folds.Add(((FoldDirection)Enum.Parse(typeof(FoldDirection), split[0].ToUpper()), int.Parse(split[1])));
                } else
                {
                    var split = item.Split(',');
                    marks.Add(new Mark() { X = int.Parse(split[0]), Y = int.Parse(split[1]) });

                    if(int.Parse(split[0]) > paperSizeX)
                    {
                        paperSizeX = int.Parse(split[0]);
                    }

                    if (int.Parse(split[1]) > paperSizeY)
                    {
                        paperSizeY = int.Parse(split[1]);
                    }
                }
            }

            foreach ((FoldDirection Direction, int Amount) fold in folds)
            {
                if(fold.Direction == FoldDirection.X) {
                    marks.Where(m => m.X >= fold.Amount).ToList().ForEach(m => m.X = fold.Amount - (m.X - fold.Amount));
                    paperSizeX = fold.Amount - 1;
                    break;
                } else
                {
                    marks.Where(m => m.Y >= fold.Amount).ToList().ForEach(m => m.Y = fold.Amount - (m.Y - fold.Amount));
                    paperSizeY = fold.Amount - 1;
                    break;
                }
            }

            List<Mark> result = new List<Mark>();
            result.AddRange(marks.GroupBy(m => new { m.X, m.Y }).SelectMany(g => g).Distinct(new MarkComparer()).ToList());

            int count = 0;
            for(var i=0; i<=paperSizeY; i++)
            {
                for(var j=0; j<=paperSizeX; j++)
                {
                    if(marks.Any(m => m.Y == i && m.X == j))
                    {
                        //Log($"#", null);
                        count++;

                    } else
                    {
                        //Log($".", null);
                    }
                    
                }

                //Log($"\n", null);
            }

            Log($"Answer1: {count}\n", null);
        }

    }

    public enum FoldDirection
    {
        X,
        Y
    }

    public class Mark
    {
        public int X { get; set; }
        public int Y { get; set; }


    }

    public class MarkComparer : IEqualityComparer<Mark>
    {
        public bool Equals(Mark g1, Mark g2)
        {
            return g1.X == g2.X && g1.Y == g2.Y;
        }

        public int GetHashCode(Mark obj)
        {
            //throw new NotImplementedException();
            return -1;
        }
    }
}
