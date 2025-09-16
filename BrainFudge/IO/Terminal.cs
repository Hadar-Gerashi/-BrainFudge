using BrainFudge.CoreMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace BrainFudge.IO
{
    public class Terminal : ITerminal
    {
        private static Terminal? instance;
        private static readonly object lockObj = new object();

        private Terminal() { }

        public static Terminal Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                        instance = new Terminal();
                    return instance;
                }
            }
        }

        public void Write(char s)
        {
            Console.Write(s);
        }

        public char ReadChar()
        {
            Console.Write("Enter char: ");
            int input = Console.Read();
            Console.ReadLine();
            return (char)input;
        }

        public void Display(Memory memory)
        {
            if (!Console.IsOutputRedirected && Environment.UserInteractive)
                Console.Clear();

            Console.WriteLine();

            int length = memory.MaxUsedIndex + 1;
            int cellWidth = 5;


            string CenterText(string text, int width)
            {
                int padding = width - text.Length;
                int padLeft = padding / 2;
                int padRight = padding - padLeft;
                return new string(' ', padLeft) + text + new string(' ', padRight);
            }

            for (int i = 0; i < length; i++)
            {
                string value = memory.Ram.GetCell(i)?.Value.ToString() ?? ".";
                string cellText = CenterText(value, cellWidth);

                if (i == memory.Pointer)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.Write(cellText);
                Console.ResetColor();
            }
            Console.WriteLine();


            for (int i = 0; i < length; i++)
            {
                var cell = memory.Ram.GetCell(i);
                string? output = (cell == null || cell.Output == null || cell.Output.ToString() == "0") ? "." : cell.Output.ToString();
                string cellText = CenterText(output!, cellWidth);

                if (i == memory.Pointer)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.Write(cellText);
                Console.ResetColor();
            }
            Console.WriteLine("\n");
        }



        public void DisplayFinalOutput(Memory memory)
        {

            if (memory.AllOutput != null && memory.AllOutput.Count > 0)
            {
                Console.Write("Program output: ");
                foreach (var c in memory.AllOutput)
                {
                    Console.Write(c);
                }
                Console.WriteLine();
            }
        }

    }

}
