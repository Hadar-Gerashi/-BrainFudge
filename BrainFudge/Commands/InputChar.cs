using BrainFudge.CoreMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFudge.Comands
{
    // , = A => m[p]=65;
    internal class InputChar : Command
    {
        public InputChar(int count = 1) : base(count) { }
        public override void Execute(Interpreter interpreter, Memory memory)
        {

            memory.InputChar(Count);

        }
    }
}
