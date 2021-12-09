using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021WinForms
{
    public abstract class Solver
    {
        public Action<string, Color?> Log;

        public Solver(Action<string, Color?> log)
        {
            Log = log;
        }
    }
}
