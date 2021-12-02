using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021WinForms
{
    public abstract class Solver
    {
        public Action<string> Log;

        public Solver(Action<string> log)
        {
            Log = log;
        }
    }
}
