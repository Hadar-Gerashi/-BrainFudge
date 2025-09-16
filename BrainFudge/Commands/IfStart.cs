using BrainFudge.CoreMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFudge.Comands
{
    // { =  אם התא שעכשיו שווה 0 אז תגיע עד אחרי ה : שלו
    // זה בעצם מבטא את הelse;
    internal class IfStart : Command
    {
        public override void Execute(Interpreter interpreter, Memory memory)
        {

            int ip = interpreter.GetIP();
            List<Command> commands = interpreter.GetCommands();

            if (memory.GetCell() == 0)
            {
                int blockLevel = 1;
                int jumpIp = ip + 1;


                while (jumpIp < commands.Count &&
                      !((commands[jumpIp] is ElseBlock && blockLevel == 1)))
                {
                    if (commands[jumpIp] is IfStart)
                        blockLevel++;
                    else if (commands[jumpIp] is IfEnd)
                        blockLevel--;

                    jumpIp++;
                }

                interpreter.JumpTo(jumpIp);
            }




        }
    }
}
