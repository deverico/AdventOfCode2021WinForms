using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021WinForms.Day12
{
    public class Day12Solver : Solver
    {

        public Day12Solver(Action<string, Color?> log) : base(log) { }

        public void Solve(string[] input)
        {
            Part1(input);
            Part2(input);
        }

        private void Part2(string[] input)
        {
            Dictionary<string, Node> nodes = new Dictionary<string, Node>();

            foreach (var route in input)
            {
                var split = route.Split('-');
                Node sourceNode;
                Node destinationNode;
                if (!nodes.ContainsKey(split[0]))
                {
                    sourceNode = CreateNode(split[0]);
                    nodes.Add(split[0], sourceNode);
                }
                else
                {
                    sourceNode = nodes[split[0]];
                }

                if (!nodes.ContainsKey(split[1]))
                {
                    destinationNode = CreateNode(split[1]);
                    nodes.Add(split[1], destinationNode);
                }
                else
                {
                    destinationNode = nodes[split[1]];
                }

                AddPath(sourceNode, destinationNode);
            }

            GetAllPaths(nodes, true);
        }

        private void Part1(string[] input)
        {

            Dictionary<string, Node> nodes = new Dictionary<string, Node>();

            foreach (var route in input)
            {
                var split = route.Split('-');
                Node sourceNode;
                Node destinationNode;
                if (!nodes.ContainsKey(split[0]))
                {
                    sourceNode = CreateNode(split[0]);
                    nodes.Add(split[0], sourceNode);
                }
                else
                {
                    sourceNode = nodes[split[0]];
                }

                if (!nodes.ContainsKey(split[1]))
                {
                    destinationNode = CreateNode(split[1]);
                    nodes.Add(split[1], destinationNode);
                }
                else
                {
                    destinationNode = nodes[split[1]];
                }

                AddPath(sourceNode, destinationNode);
            }

            GetAllPaths(nodes, false);
        }

        private void GetAllPaths(Dictionary<string, Node> nodes, bool isPart2)
        {
            List<List<Node>> paths = new List<List<Node>>();

            Node startNode = nodes.First(x => x.Value.IsStart).Value;
            Node endNode = nodes.First(x => x.Value.IsEnd).Value;

            if (isPart2)
            {
                TraversePart2(startNode, paths, null);
            }
            else
            {
                TraversePart1(startNode, paths, null);
            }

            List<List<Node>> complete = paths.Where(x => x.Any(y => y.IsEnd)).ToList();

            //complete.ForEach(x => Log($"{string.Join(",", x)}\n", null));
            
            Log($"Answer{(isPart2 ? "2" : "1")}: {complete.Count}\n", null);
        }

        private void TraversePart1(Node node, List<List<Node>> paths, List<Node> pathTohere)
        {
            if (node.IsStart && pathTohere != null && pathTohere.Any(x => x.IsStart))
            {
                return;
            }

            if (node.IsEnd)
            {
                var newPath = new List<Node>();
                newPath.AddRange(pathTohere);
                newPath.Add(node);
                paths.Add(newPath);
                return;
            }

            if (pathTohere != null && pathTohere.Any(n => n.IsEnd))
            {
                return;
            }

            var nextPath = new List<Node>();
            if (pathTohere != null)
            {
                if (!node.CanTraverseMultipleTimes && pathTohere.Contains(node))
                {
                    return;
                }

                // new path should contain route to here.
                nextPath.AddRange(pathTohere);
            }


            paths.Add(nextPath);
            nextPath.Add(node);

            foreach (var nextNode in node.Paths)
            {
                TraversePart1(nextNode, paths, nextPath);
            }
        }

        private void TraversePart2(Node node, List<List<Node>> paths, List<Node> pathTohere)
        {
            if(node.IsStart && pathTohere != null && pathTohere.Any(x => x.IsStart))
            {
                return;
            }

            if (node.IsEnd)
            {
                var newPath = new List<Node>();
                newPath.AddRange(pathTohere);
                newPath.Add(node);
                paths.Add(newPath);
                return;
            }

            if (pathTohere != null && pathTohere.Any(n => n.IsEnd))
            {
                return;
            }

            var nextPath = new List<Node>();
            if (pathTohere != null)
            {                
                var maxCount = pathTohere.Where(x => !x.CanTraverseMultipleTimes).GroupBy(s => s).Select(g => new { Node = g.Key, Count = g.Count() });
                if (!node.CanTraverseMultipleTimes && maxCount.Any(x => x.Count == 2) && pathTohere.Contains(node))
                {
                    return;
                }

                // new path should contain route to here.
                nextPath.AddRange(pathTohere);
            }
            
            paths.Add(nextPath);   
            nextPath.Add(node);

            foreach(var nextNode in node.Paths)
            {
                TraversePart2(nextNode, paths, nextPath);
            }
        }

        public Node CreateNode(string s)
        {
            Node n = new Node();

            n.Name = s;

            if(s == "start")
            {
                n.IsStart = true;
            } else if(s == "end")
            {
                n.IsEnd = true;
            }

            if (char.IsUpper(s[0]))
            {
                n.CanTraverseMultipleTimes = true;
            }

            return n;
        }

        public void AddPath(Node source, Node destination)
        {
            source.Paths.Add(destination);
            
            if(!source.IsStart)// && !source.IsEnd)
            {
                destination.Paths.Add(source);
            }

        }
    }

    public class Node
    {
        public string Name = String.Empty;

        public bool IsStart { get; set; }

        public bool IsEnd { get; set; }

        public bool CanTraverseMultipleTimes { get; set; }

        public List<Node> Paths { get; set; } = new List<Node>();

        public override string ToString()
        {
            return Name;
        }

    }
}
