using BrainFudge.Comands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFudge.Engine
{
    internal class Optimizer
    {

        public CommandList Optimize(CommandList commands)
        {
            var optimized = new CommandList();
            Command? current = null;
            List<Command> listCommand = commands.GetCommands();
            int count = 0;

            foreach (var next in listCommand)
            {
                if (current != null && next.GetType() == current.GetType() &&SupportsCounting(current))
                {
                    count++;
                }
                else
                {
                    if (current != null)
                        optimized.AddCommand(CreateOptimizedCommand(current, count));

                    current = next;
                    count = 1;
                }
            }

            if (current != null)
                optimized.AddCommand(CreateOptimizedCommand(current, count));

            return optimized;
        }


        private bool SupportsCounting(Command cmd) =>
            cmd is Increment || cmd is Decrement || cmd is MoveRight || cmd is MoveLeft || cmd is InputChar || cmd is OutputChar;

        private Command CreateOptimizedCommand(Command command, int count) =>
     command switch
     {
         Increment => new Increment(count),
         Decrement => new Decrement(count),
         MoveRight => new MoveRight(count),
         MoveLeft => new MoveLeft(count),
         InputChar => new InputChar(count),
         OutputChar => new OutputChar(count),
         _ => command
     };

    }


}
