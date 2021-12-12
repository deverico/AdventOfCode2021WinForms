using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021WinForms.Day11
{
    public class Day11Solver : Solver
    {

        public Day11Solver(Action<string, Color?> log) : base(log) { }

        public void Solve(string[] input)
        {
            List<Octopus> octopi = input.SelectMany((row, indexi) => row.ToCharArray().Select((character, indexj) => new Octopus() { Flash = int.Parse(character.ToString()), I = indexi, J = indexj })).ToList();
            PopulateNeighbours(octopi);

            Part1(octopi);
            Part2(octopi);
        }


        private void Part2(List<Octopus> octopi)
        {
            int steps = 1000;
            int flashCount = 0;
            int previousCount = 0;

            for (var i = 0; i < steps; i++)
            {
                octopi.ForEach(octo => octo.Trigger(ref flashCount));
                octopi.Where(octo => octo.Flash == 10).ToList().ForEach(octo => octo.Flash = 0);
                if(flashCount == previousCount + 100)
                {
                    Log($"Answer2: {i+1}\n", null);
                    break;
                } else
                {
                    previousCount = flashCount;
                }
            }            
        }

        private void Part1(List<Octopus> octopi)
        {
            int steps = 100;
            int flashCount = 0;

            for (var i = 0; i < steps; i++)
            {
                octopi.ForEach(octo => octo.Trigger(ref flashCount));
                octopi.Where(octo => octo.Flash == 10).ToList().ForEach(octo => octo.Flash = 0);                
            }

            Log($"Answer1: {flashCount}\n", null);
        }

        private void PopulateNeighbours(IEnumerable<Octopus> octopi)
        {
            octopi.ToList().ForEach(octopus =>
            {
                AddNeighbour(octopus, octopus.I + 1, octopus.J, octopi);
                AddNeighbour(octopus, octopus.I - 1, octopus.J, octopi);
                AddNeighbour(octopus, octopus.I, octopus.J + 1, octopi);
                AddNeighbour(octopus, octopus.I, octopus.J - 1, octopi);
                AddNeighbour(octopus, octopus.I + 1, octopus.J + 1, octopi);
                AddNeighbour(octopus, octopus.I + 1, octopus.J - 1, octopi);
                AddNeighbour(octopus, octopus.I - 1, octopus.J + 1, octopi);
                AddNeighbour(octopus, octopus.I - 1, octopus.J - 1, octopi);
            });
        }

        public void AddNeighbour(Octopus o, int i, int j, IEnumerable<Octopus> octopi)
        {
            try
            {
                var exists = octopi.First(octo => octo.I == i && octo.J == j);
                
                if(exists  != null)
                {
                    o.Neighbours.Add(exists);
                }
            } catch(Exception)
            {
            }
        }
    }

    public class Octopus {

        public int I { get; set; }
        public int J { get; set; }

        public int Flash { get; set; }

        public List<Octopus> Neighbours { get; set; } = new List<Octopus>();

        public void Trigger(ref int flashCount)
        {
            int flashCountDeep = 0;
            if (Flash == 10) return;

            Flash++;

            if(Flash == 10)
            {
                flashCount++;
                Neighbours.ToList().ForEach(neightbour => neightbour.Trigger(ref flashCountDeep));

                flashCount += flashCountDeep;
            }
        }


    }

}
