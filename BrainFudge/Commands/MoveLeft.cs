using BrainFudge.CoreMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFudge.Comands
{
    // < = --p;
    internal class MoveLeft : Command
    {
        public MoveLeft(int count=1) : base(count) { }

        public override void Execute(Interpreter interpreter, Memory memory)
        {
            memory.MoveLeft(Count);
        }
    }
}
