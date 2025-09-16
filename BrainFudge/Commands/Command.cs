using BrainFudge.CoreMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFudge.Comands
{
    public abstract class Command
    {
        public int Count { get; protected set; }

        public Command(int count = 1)
        {
            Count = count;
        }

        public abstract void Execute(Interpreter interpreter, Memory memory);
    }
}
