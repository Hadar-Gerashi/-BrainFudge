using BrainFudge.CoreMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFudge.Comands
{
    // [ = if(m[p]==0) skip(']');
    internal class LoopStart : Command
    {

        public override void Execute(Interpreter interpreter, Memory memory)
        {
            if (memory.GetCell() == 0)
            {
                int open = 1;
                int ip = interpreter.GetIP();
                List<Command> commands = interpreter.GetCommands();

                while (open > 0)
                {
                    ip++;
                    if (commands[ip] is LoopStart) open++;
                    else if (commands[ip] is LoopEnd) open--;
                }

                interpreter.JumpTo(ip); 
            }

        }
    }
}
