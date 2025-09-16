using BrainFudge.Comands;
using BrainFudge.CoreMemory;
using BrainFudge.Engine;
using BrainFudge.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFudge.App
{
    public class BrainFudgeApp
    {
        private readonly string path;
        private readonly int memorySize;
        private readonly Debugger debugger;

        public BrainFudgeApp(string path, Debugger debugMode, int memorySize = 10)
        {
            this.path = path;
            this.memorySize = memorySize;
            debugger = debugMode;
        }

        public void Run()
        {
            try
            {
                var reader = new CodeReader(path);
                string rawCode = reader.ReadCode();

                var analyzer = new SyntaxAnalyzer(rawCode);
                string cleanCode = analyzer.Analyze();

                var compiler = new Compiler(cleanCode);
                CommandList commands = compiler.Compile();

                CommandList commandsToRun;

                if (debugger.State == DebugState.Off)
                {
                    var optimizer = new Optimizer();
                    commandsToRun = optimizer.Optimize(commands);
                }
                else
                {
                    commandsToRun = commands;
                }

                Memory memory = new Memory();
                Terminal terminal = Terminal.Instance;
                Interpreter interpreter = new Interpreter(memory, terminal, commandsToRun, debugger);

                interpreter.Run();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
            }
        }


    }
}
