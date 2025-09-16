using BrainFudge.CoreMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFudge.Comands
{
    // + = m[p]++;
    internal class Increment : Command
    {
        public Increment(int count=1) : base(count) { }
        public override void Execute(Interpreter interpreter, Memory memory)
        {

            memory.Increment(Count);

        }
    }
}
