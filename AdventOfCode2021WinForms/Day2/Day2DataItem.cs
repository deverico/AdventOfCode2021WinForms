using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021WinForms.Day2
{
    public enum Direction
    {
        Forward,
        Up,
        Down
    }

    public class Day2DataItem
    {
        public Direction SubDirection;
        public int MoveDistance;

        public override string ToString()
        {
            return $"{Enum.GetName(typeof(Direction), SubDirection)}, {MoveDistance}";
        }
    }
}
