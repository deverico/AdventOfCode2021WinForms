using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021WinForms.Day3
{
    public class Day3Solver : Solver
    {

        public Day3Solver(Action<string, Color?> log) : base(log) { }

        public void Solve(string[] input)
        {

            StringBuilder gamma = new StringBuilder();
            StringBuilder epsilon = new StringBuilder();

            for (var i = 0; i < input[0].Count(); i++) {
                var whichBit = input.Select(x => x[i]).GroupBy(x => x).Select(y => (a: y.Key, b: y.Count())).ToArray();

                if (whichBit[0].b > whichBit[1].b)
                {
                    gamma.Append(whichBit[0].a);
                    epsilon.Append(whichBit[1].a);
                }
                else
                {
                    gamma.Append(whichBit[1].a);
                    epsilon.Append(whichBit[0].a);
                }
            }

            Log($"Gamma {gamma}, epsilon {epsilon}\n", null);
            var g = Convert.ToInt32(gamma.ToString(), 2);
            var e = Convert.ToInt32(epsilon.ToString(), 2);             
            Log($"g={g}, e={e}\n", null);
            Log($"Answer1 {g * e}\n", null);


            // part 2

            List<string> oxygenList = new List<string>(input);
            List<string> co2List = new List<string>(input);

            var oxygen = GetRating(oxygenList, true);
            var co2 = GetRating(co2List, false);

            var oxy = Convert.ToInt32(oxygen.ToString(), 2);
            Log($"Oxy: {oxygen}, {oxy}\n", null);
            var co22 = Convert.ToInt32(co2.ToString(), 2);
            Log($"Co2: {co2}, {co22}\n", null);
            Log($"Answer2 {oxy * co22}\n", null);

        }

        public string GetRating(List<string> list, bool isOxygen)
        {
            int bitIndex = 0;
            while (list.Count > 1)
            {
                var whichBit = list.Select(x => x[bitIndex]).GroupBy(x => x).Select(y => (a: y.Key, b: y.Count())).ToArray();

                if (whichBit[0].b > whichBit[1].b)
                {
                    if (isOxygen)
                    {
                        // there are more 0 bits, so remove any 1 bits
                        list.RemoveAll(x => x[bitIndex] == whichBit[1].a);
                    } else
                    {
                        list.RemoveAll(x => x[bitIndex] == whichBit[0].a);
                    }

                }
                else if (whichBit[0].b == whichBit[1].b)
                {
                    if (isOxygen)
                    {
                        // same amount, for oxygen keep 1 bits
                        list.RemoveAll(x => x[bitIndex] == '0');//??
                    } else
                    {
                        // same amount, for oxygen keep 0 bits
                        list.RemoveAll(x => x[bitIndex] == '1');//??
                    }
                }
                else
                {
                    if (isOxygen)
                    {
                        // there are more 1 bits, so remove any 0 bits
                        list.RemoveAll(x => x[bitIndex] == whichBit[0].a);
                    } else
                    {
                        list.RemoveAll(x => x[bitIndex] == whichBit[1].a);
                    }
                }


                bitIndex++;
            }

            return list[0];
        }
    }
}
