using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021WinForms.Day2
{
    public class Day2Solver : Solver
    {

        public Day2Solver(Action<string, Color?> log) : base(log) {}

        public void Solve(string[] input)
        {
            var data = ParseInput(input);

            int distanceForward = CalculateDistanceForward(data);
            int finalDepth = CalculateFinalDepth(data);
            Log($"Forward: {distanceForward}, Depth: {finalDepth}\n", null);

            int answer1 = distanceForward * finalDepth;
            Log($"Answer1: {answer1}\n", null);


            (int distanceForward2, int finalDepth2) = Part2(data);
            Log($"Forward: {distanceForward2}, Depth: {finalDepth2}\n", null);
            int answer2 = distanceForward2 * finalDepth2;
            Log($"Answer2: {answer2}\n", null);
        }

        private (int, int) Part2(List<Day2DataItem> data)
        {
            int forward = 0;
            int depth = 0;
            int aim = 0;
            foreach(var d in data)
            {
                switch(d.SubDirection)
                {
                    case Direction.Down:
                        aim += d.MoveDistance;
                        break;
                    case Direction.Up:
                        aim -= d.MoveDistance;
                        break;
                    case Direction.Forward:
                        forward += d.MoveDistance;
                        depth += aim * d.MoveDistance;
                        break;
                }
            }

            return (forward, depth);
        }

        private int CalculateDistanceForward(List<Day2DataItem> data)
        {
            return data.Where(x => x.SubDirection == Direction.Forward).Sum(x => x.MoveDistance);
        }

        private int CalculateFinalDepth(List<Day2DataItem> data)
        {
            int allDDowns = data.Where(x => x.SubDirection == Direction.Down).Sum(x => x.MoveDistance);
            int allUps = data.Where(x => x.SubDirection == Direction.Up).Sum(x => x.MoveDistance);
            return allDDowns - allUps;
        }

        private List<Day2DataItem> ParseInput(string[] input)
        {
            List<Day2DataItem> d = new List<Day2DataItem>();

            foreach (var line in input)
            {
                var split = line.Split(' ');
                var item = new Day2DataItem() { SubDirection = StringToDirection(split[0]), MoveDistance = int.Parse(split[1]) };
                d.Add(item);
                //Log(item.ToString() + "\n");
            }            

            return d;
        }

        private Direction StringToDirection(string s)
        {
            switch(s)
            {
                case "forward":
                    return Direction.Forward;
                case "up":
                    return Direction.Up;
                case "down":
                    return Direction.Down;
                default:
                    throw new Exception("bad direction");
            }
        }       
    }
}
