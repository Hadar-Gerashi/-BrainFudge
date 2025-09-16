using BrainFudge.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace BrainFudge.CoreMemory
{
    public class Memory
    {

        private ITerminal terminal = Terminal.Instance;
        public DynamicArray Ram { get; private set; }
        public List<char> AllOutput { get; } = new List<char>();

        public int MaxUsedIndex { get; private set; }
        private int pointer;
        public int Pointer
        {
            get => pointer;
            set
            {
                pointer = value;
                if (pointer > MaxUsedIndex) MaxUsedIndex = pointer;
            }
        }



        public Memory(int size = 5)
        {
            Pointer = 0;
            Ram = new DynamicArray(size);

        }

        public int GetPointer()
        {
            return Pointer;
        }
        public byte GetCell(int? index = null)
        {
            int i = index ?? Pointer;
            return Ram.GetCell(i).Value;
        }



        public void Increment(int count = 1)
        {
            byte newValue = (byte)((Ram.GetCell(Pointer).Value + count) % 256);
            Ram.SetCell(Pointer, newValue);

        }

        public void Decrement(int count = 1)
        {
            byte newValue = (byte)((Ram.GetCell(Pointer).Value - count + 256) % 256);
            Ram.SetCell(Pointer, newValue);
        }



        public void MoveRight(int count = 1)
        {
            Pointer += count;
            Ram.EnsureRightCapacity(Pointer);

        }

        public void MoveLeft(int count = 1)
        {
            Pointer -= count;

            if (Pointer < 0)
            {
                int shift = -Pointer;
                Ram.EnsureLeftCapacity(shift);
                Pointer = 0;
                MaxUsedIndex += shift;
            }

        }

        public void InputChar(int count = 1)
        {
            char c = ' ';
            for (int i = 0; i < count; i++)
            {
                c = terminal.ReadChar();

            }
            Ram.SetCell(Pointer, (byte)c);

        }


        public void OutputChar(int count = 1)
        {
            char c = (char)Ram.GetCell(Pointer).Value;
            for (int i = 0; i < count; i++)
            {
                Ram.SetOutput(c, Pointer);
                AllOutput.Add(c);
            }


        }


    }
}
