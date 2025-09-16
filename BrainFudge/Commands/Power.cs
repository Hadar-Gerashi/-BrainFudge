using BrainFudge.CoreMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFudge.Comands
{
    internal class Power : Command
    {
        // ^ = cell3 = math.power(cell1,cell2) ;
        public override void Execute(Interpreter interpreter, Memory memory)
        {
            byte cell1=memory.GetCell(memory.Pointer);
            memory.MoveRight(1);
            byte cell2 =memory.GetCell(memory.Pointer);
            double power = Math.Pow(cell1, cell2);
            byte result = (byte)((int)power % 256);
            memory.MoveRight(1);
            memory.Ram.SetCell(memory.Pointer,result);
            memory.MoveLeft(2);
        }
    }
}
