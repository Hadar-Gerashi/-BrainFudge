using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFudge.IO
{
    internal class CodeReader
    {
        private string filePath;

        public CodeReader(string filePath = "code.bf")
        {
            this.filePath = filePath;
        }

        public string ReadCode()
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File {filePath} not found.");

            string code = File.ReadAllText(filePath);
           
            return code;
        }
    }
}
