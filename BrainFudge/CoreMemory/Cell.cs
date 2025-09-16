using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFudge.CoreMemory
{
    public class Cell
    {
        public byte Value { get; set; }
        public char? Output { get; set; }

        public Cell(byte value = 0)
        {
            Value = value;
            Output = null;
        }
    }

}
