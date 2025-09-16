using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFudge.IO
{

    public interface ITerminal
    {
        char ReadChar();
        void Write(char c);
    }


}
