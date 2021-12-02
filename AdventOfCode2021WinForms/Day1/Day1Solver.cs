using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021WinForms.Day1
{
    public class Day1Solver
    {
        Action<string> Log;

        public Day1Solver(Action <string> log)
        {
            Log = log;     
        }

        private int WindowSize = 3;

        public void Solve(int[] input)
        {
            List<DataItem> data = new List<DataItem>();
            int i = 1;
            data.Add(new DataItem() { originalDepth = input[0], isFirst = true });
            while (i < input.Length)
            {
                var currentItem = new DataItem() { originalDepth = input[i], Previous = data[i - 1] };
                data[i - 1].Next = currentItem;
                data.Add(currentItem);

                i++;
            }

            CalculateWindow(data);
            DetermineIncrease(data);
            Display(data);

            Log($"Answer 1: {data.Where(x => x.increase && !x.isFirst).Count()}\n");
            Log($"Answer 2: {data.Where(x => x.windowIncrease && !x.isFirst).Count()}\n");
        }

        public void Display(List<DataItem> data)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Found {data.Count()} pieces of data");
            //foreach (var item in data)
            //{
            //    Log($"{item.originalDepth} -> {(item.isFirst ? "N/a" : (item.increase ? "increase" : "decrease"))}");
            //}

            Log(sb.ToString());
        }

        public bool IsIncrease(int a, int other)
        {
            return a > other;
        }

        public void CalculateWindow(List<DataItem> data)
        {
            // if window size is 3, we need to skip the last 2 elements, since they won't have window values..
            foreach (var dataItem in data.Take(Math.Max(0, data.Count() - (WindowSize - 1))))
            {
                dataItem.windowDepth = dataItem.originalDepth + dataItem.Next.originalDepth + dataItem.Next.Next.originalDepth;
            }
        }

        public void DetermineIncrease(List<DataItem> data)
        {
            foreach (var dataItem in data.Skip(1))
            {
                dataItem.increase = IsIncrease(dataItem.originalDepth, dataItem.Previous.originalDepth);
            }

            // because we skip one, we don't need -1 with the window size
            foreach (var dataItem in data.Skip(1).Take(Math.Max(0, data.Count() - WindowSize)))
            {
                dataItem.windowIncrease = IsIncrease(dataItem.windowDepth, dataItem.Previous.windowDepth);
            }

        }
    }
}
