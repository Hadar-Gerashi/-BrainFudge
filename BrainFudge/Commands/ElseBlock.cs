using BrainFudge.CoreMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFudge.Comands
{
    // : = תחפש את הסוגר המסולסל ותגיע לשם זה בצם מבטא את הthen ;
    internal class ElseBlock : Command
    {
        public override void Execute(Interpreter interpreter, Memory memory)
        {
            int ip = interpreter.GetIP();
            List<Command> commands = interpreter.GetCommands();

            int open = 0;
            int jumpTo = ip + 1;
            bool done = false;
            while (jumpTo < commands.Count && !done)
            {
                if (commands[jumpTo] is IfStart)
                {
                    open++;
                }
                else if (commands[jumpTo] is IfEnd)
                {
                    if (open == 0)
                    {
                        done = true;
                    }
                    else
                    {
                        open--;
                    }
                }

                if (!done)
                    jumpTo++;
            }

            interpreter.JumpTo(jumpTo);
        }


    }
}
