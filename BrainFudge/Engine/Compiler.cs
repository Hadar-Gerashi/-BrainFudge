using BrainFudge.Comands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFudge.Engine
{
    public class Compiler
    {
        private string cleanCode;

        public Compiler(string code)
        {
            cleanCode = code;
        }

        public CommandList Compile()
        {
            CommandList code = new CommandList();

            foreach (char c in cleanCode)
            {

                switch (c)
                {
                    case '+':
                        code.AddCommand(new Increment());
                        break;
                    case '-':
                        code.AddCommand(new Decrement());
                        break;
                    case '>':
                        code.AddCommand(new MoveRight());
                        break;
                    case '<':
                        code.AddCommand(new MoveLeft());
                        break;
                    case '.':
                        code.AddCommand(new OutputChar());
                        break;
                    case ',':
                        code.AddCommand(new InputChar());
                        break;
                    case '[':
                        code.AddCommand(new LoopStart());
                        break;
                    case ']':
                        code.AddCommand(new LoopEnd());
                        break;
                    case '{':
                        code.AddCommand(new IfStart());
                        break;
                    case ':':
                        code.AddCommand(new ElseBlock());
                        break;
                    case '}':
                        code.AddCommand(new IfEnd());
                        break;
                    case '^':
                        code.AddCommand(new Power());
                        break;
                }
            }


            return code;
        }


    }
}
