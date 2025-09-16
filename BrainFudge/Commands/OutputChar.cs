using BrainFudge.CoreMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFudge.Comands
{
    // . = [65] => return 'A';
    internal class OutputChar : Command
    {
        public OutputChar(int count = 1) : base(count) { }
        public override void Execute(Interpreter interpreter, Memory memory)
        {
            memory.OutputChar(Count);
        }
    }
}
