using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021WinForms.Day4
{
    public class Day4Solver : Solver
    {

        public Day4Solver(Action<string, Color?> log) : base(log) { }

        public void Solve(string[] input)
        {
            Part1(input);


            // Part 2

            IEnumerable<int> bingoNumbers = input[0].Split(',').ToList().Select(x => int.Parse(x));

            var inputRow = 1;            

            List<List<List<BingoCell>>> bingoGrids = new List<List<List<BingoCell>>>();
            var gridCount = 0;
            do {
                if (inputRow % 5 == 1) {           
                    
                    bingoGrids.Add(new List<List<BingoCell>>());
                    gridCount++;
                }
                var row = input[inputRow].Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToList().Select((x, index) => new BingoCell() { Number = int.Parse(x), Column = index }).ToList();
                bingoGrids[gridCount-1].Add(row);

                inputRow++;

             } while (inputRow < input.Length);



            var bingo = false;
            int currentGrid = 0;
            List<bool> gridsComplete = Enumerable.Repeat(false, bingoGrids.Count).ToList();
            
            int winningNumber = -1;
            foreach(var num in bingoNumbers)
            {
                winningNumber = num;
                currentGrid = 0;
                foreach(var grid in bingoGrids)
                {
                    foreach(var row in grid)
                    {
                        if(row.Any(x => x.Number == num))
                        {
                            var found = row.First(x => x.Number == num);
                            found.WasCalled = true;
                            if(row.All(x => x.WasCalled))
                            {
                                
                                gridsComplete[currentGrid] = true;
                                if (gridsComplete.All(x => x == true))
                                {
                                    bingo = true;
                                    break;
                                }
                            }

                            var foundCol = true;
                            foreach(var row2 in grid)
                            {
                                if (!row2[found.Column].WasCalled)
                                {
                                    foundCol = false;
                                    break;
                                }
                            }

                            if(foundCol)
                            {
                                gridsComplete[currentGrid] = true;
                                if (gridsComplete.All(x => x == true))
                                {
                                    bingo = true;
                                    break;
                                }
                                //bingo = true;
                                //break;
                            }

                        }
                    }

                    if(bingo) {
                        break;
                    }
                    currentGrid++;
                }

                if(bingo)
                {
                    break;
                }
            }



            int theSum = 0;
            foreach(var row in bingoGrids[currentGrid])
            {
                theSum += row.Where(x => !x.WasCalled).Sum(x => x.Number);
            }
            Log($"Bingo for grid {currentGrid}, answer: {theSum * winningNumber}!\n", null);


        }

        private void Part1(string[] input)
        {
            IEnumerable<int> bingoNumbers = input[0].Split(',').ToList().Select(x => int.Parse(x));

            var inputRow = 1;

            List<List<List<BingoCell>>> bingoGrids = new List<List<List<BingoCell>>>();
            var gridCount = 0;
            do
            {
                if (inputRow % 5 == 1)
                {

                    bingoGrids.Add(new List<List<BingoCell>>());
                    gridCount++;
                }
                var row = input[inputRow].Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToList().Select((x, index) => new BingoCell() { Number = int.Parse(x), Column = index }).ToList();
                bingoGrids[gridCount - 1].Add(row);

                inputRow++;

            } while (inputRow < input.Length);



            var bingo = false;
            int currentGrid = 0;
            int winningNumber = -1;
            foreach (var num in bingoNumbers)
            {
                winningNumber = num;
                currentGrid = 0;
                foreach (var grid in bingoGrids)
                {
                    foreach (var row in grid)
                    {
                        if (row.Any(x => x.Number == num))
                        {
                            var found = row.First(x => x.Number == num);
                            found.WasCalled = true;
                            if (row.All(x => x.WasCalled))
                            {
                                bingo = true;
                                break;
                            }

                            var foundCol = true;
                            foreach (var row2 in grid)
                            {
                                if (!row2[found.Column].WasCalled)
                                {
                                    foundCol = false;
                                    break;
                                }
                            }

                            if (foundCol)
                            {
                                bingo = true;
                                break;
                            }

                        }
                    }

                    if (bingo)
                    {
                        break;
                    }
                    currentGrid++;
                }

                if (bingo)
                {
                    break;
                }
            }



            int theSum = 0;
            foreach (var row in bingoGrids[currentGrid])
            {
                theSum += row.Where(x => !x.WasCalled).Sum(x => x.Number);
            }
            Log($"Bingo for grid {currentGrid}, answer: {theSum * winningNumber}!\n", null);
        }
    }

    public class BingoCell
    {
        public int Number { get; set; }

        public int Column { get; set; }

        public bool WasCalled { get; set; }
    }
}
