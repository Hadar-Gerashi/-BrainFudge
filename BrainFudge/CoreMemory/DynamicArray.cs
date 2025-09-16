using System.Reflection;
using System.Runtime.Intrinsics.Arm;

namespace BrainFudge.CoreMemory
{
    public class DynamicArray
    {
        private const int EXPAND_FACTOR = 2;
        private Cell[] cells;

        public int Length => cells.Length;

        public DynamicArray(int size)
        {
            cells = new Cell[size];
            for (int i = 0; i < size; i++)
                cells[i] = new Cell();
        }

        public void SetOutput(char output, int pointer)
        {
            cells[pointer].Output = output;
        }

        public Cell GetCell(int index)
        {
            return cells[index];
        }


        public void SetCell(int index, byte value)
        {
            cells[index].Value = value;
        }

        public void EnsureRightCapacity(int index)
        {
            if (index >= cells.Length)
            {
                int newSize = cells.Length * EXPAND_FACTOR;
                while (index >= newSize) newSize *= EXPAND_FACTOR;
                var newCells = new Cell[newSize];
                Array.Copy(cells, newCells, cells.Length);
                for (int i = cells.Length; i < newSize; i++)
                    newCells[i] = new Cell();
                cells = newCells;
            }
        }

        public void EnsureLeftCapacity(int shift)
        {
            int newSize = cells.Length * EXPAND_FACTOR;
            while (shift >= newSize) newSize *= EXPAND_FACTOR;
            var newCells = new Cell[newSize];
            Array.Copy(cells, 0, newCells, shift, cells.Length);
            for (int i = 0; i < shift; i++)
                newCells[i] = new Cell();
            cells = newCells;
        }
    }
}