using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021WinForms
{
    public class DataItem
    {
        public bool isFirst;
                
        public int originalDepth;
        public bool increase;

        public int windowDepth;
        public bool windowIncrease;

        public DataItem Next = null;
        public DataItem Previous = null;
    }
}
