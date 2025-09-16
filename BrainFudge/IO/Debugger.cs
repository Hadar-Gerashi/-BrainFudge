using System;
using System.Collections.Generic;
using BrainFudge.Comands;
using BrainFudge.CoreMemory;
namespace BrainFudge.IO
{
    public enum DebugState
    {
        Step,      // מצב פקודה-פקודה
        Continue,  // ריצה רציפה עד הסוף
        Off        // אין דיבאג בכלל
    }

    public enum DebugAction
    {
        Next,      // להריץ פקודה אחת
        Continue   // לרוץ עד הסוף
    }

    public class Debugger
    {
        private DebugState state;


        public Debugger(bool debugMode)
        {
            state = debugMode ? DebugState.Step : DebugState.Off;
        }

        public DebugState State => state;

        public void SetState(DebugState newState)
        {
            state = newState;
        }

        public DebugAction HandleDebug(Memory memory, Command currentCommand)
        {
            if (state == DebugState.Off || state == DebugState.Continue)
                return DebugAction.Continue;

            Console.Clear();
            Terminal.Instance.Display(memory);

            Console.WriteLine("command current: " + currentCommand.GetType().Name);
            Console.WriteLine();
            Console.WriteLine("- n : Execute next command step");
            Console.WriteLine("- c : Continue execution until the end");
            Console.WriteLine("- q : Quit debugger and exit program");

            var key = char.ToLower(Console.ReadKey(true).KeyChar);

            if (key == 'c')
            {
                state = DebugState.Continue;
                return DebugAction.Continue;
            }

            else if (key == 'q')
            {
                Environment.Exit(0);
            }

            return DebugAction.Next;
        }
    }
}
