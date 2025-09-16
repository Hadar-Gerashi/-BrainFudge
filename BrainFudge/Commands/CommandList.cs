using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFudge.Comands
{
    public class CommandList
    {

        private List<Command> commands = new List<Command>();

        public void AddCommand(Command cmd)
        {
            commands.Add(cmd);
        }


        public List<Command> GetCommands()
        {
            return commands;
        }

       

    }
}
