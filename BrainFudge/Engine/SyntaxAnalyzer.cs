using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFudge.Engine
{
    public class SyntaxAnalyzer
    {
        private string code;

        public SyntaxAnalyzer(string code)
        {
            this.code = code;
        }
        public string Analyze()
        {

            code = new string(code.Where(c => "+-<>.,[]{:}^".Contains(c)).ToArray());

            Stack<(char type, int position, bool hasColon)> stack = new();

            for (int i = 0; i < code.Length; i++)
            {
                char c = code[i];

                if (c == '{')
                    stack.Push((c, i, false));
                else if (c == ':')
                {
                    if (stack.Count == 0 || stack.Peek().type != '{')
                        throw new Exception($"Syntax Error: ':' at position {i} not inside '{{ }}'");

                    var top = stack.Pop();
                    stack.Push((top.type, top.position, true));
                }
                else if (c == '}')
                {
                    if (stack.Count == 0)
                        throw new Exception($"Syntax Error: '}}' at position {i} has no matching '{{'.");

                    var top = stack.Pop();
                    if (top.type != '{')
                        throw new Exception($"Syntax Error: Mismatched block at position {top.position} and {i}");

                    if (!top.hasColon)
                        throw new Exception($"Syntax Error: Block starting at {top.position} has no ':'");
                }
                else if (c == '[')
                    stack.Push((c, i, false));
                else if (c == ']')
                {
                    if (stack.Count == 0)
                        throw new Exception($"Syntax Error: ']' at position {i} has no matching '['.");

                    var top = stack.Pop();
                    if (top.type != '[')
                        throw new Exception($"Syntax Error: Mismatched '[' at {top.position} with ']' at {i}");
                }
            }

            if (stack.Count > 0)
                throw new Exception("Syntax Error: Some blocks were not closed.");



            return code;

        }
    }

}
