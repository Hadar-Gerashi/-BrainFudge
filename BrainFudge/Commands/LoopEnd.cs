using BrainFudge.CoreMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFudge.Comands
{
    // ] = come back to '[';
    internal class LoopEnd : Command
    {

        public override void Execute(Interpreter interpreter, Memory memory)
        {
            if (memory.GetCell() != 0)
            {
                int close = 1;
                int ip = interpreter.GetIP();
                List<Command> commands = interpreter.GetCommands();

                while (close > 0)
                {
                    ip--;
                    if (commands[ip] is LoopEnd) close++;
                    else if (commands[ip] is LoopStart) close--;
                }

                interpreter.JumpTo(ip); 
            }
        }
    }
}
