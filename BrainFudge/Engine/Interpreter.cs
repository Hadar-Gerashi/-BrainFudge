using System;
using System.Collections.Generic;
using BrainFudge.IO;
using BrainFudge.Comands;
using BrainFudge.Engine;
using BrainFudge.CoreMemory;

namespace BrainFudge
{
    public class Interpreter
        {
            private int ip = 0; // Instruction Pointer
            private readonly Memory memory;
            private readonly Terminal terminal;
            private readonly CommandList commandList;
            private readonly Debugger debugger;


            public Interpreter(Memory memory, Terminal terminal, CommandList commandList, Debugger? debugger = null)
            {
                this.memory = memory;
                this.terminal = terminal;
                this.commandList = commandList;
                this.debugger = debugger ?? new Debugger(false);


            }


            public void Run()
            {
                List<Command> commands = commandList.GetCommands();

                while (ip < commands.Count)
                {


                    if (debugger.State != DebugState.Off)
                    {
                        var action = debugger.HandleDebug(memory, commands[ip]);

                        if (action == DebugAction.Continue)
                        {
                            debugger.SetState(DebugState.Off);
                            CommandList remaining = new CommandList();
                            for (int i = ip; i < commands.Count; i++)
                                remaining.AddCommand(commands[i]);

                            var optimizer = new Optimizer();
                            var optimized = optimizer.Optimize(remaining);
                            commands.RemoveRange(ip, commands.Count - ip);
                            commands.AddRange(remaining.GetCommands());
                        }


                    }

                    commands[ip].Execute(this, memory);
                    ip++;
            
            }


                terminal.Display(memory);
                terminal.DisplayFinalOutput(memory);
            }


            public void JumpTo(int newIp) => ip = newIp;
            public int GetIP() => ip;
            public List<Command> GetCommands() => commandList.GetCommands();


        }


    }
