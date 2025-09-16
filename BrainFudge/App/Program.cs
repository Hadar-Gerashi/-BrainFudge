using BrainFudge.IO;

namespace BrainFudge.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "code.bf";
            bool debugMode = false;

            int pathIndex = 1;
            if (args.Length > 0 && args[1] == "-d")
            {
                debugMode = true;
                pathIndex = 2;
            }

            if (args.Length > pathIndex)
                path = args[pathIndex];


            Debugger debugger=new Debugger(debugMode);
            var app = new BrainFudgeApp(path, debugger);
            app.Run();
        }
    }
}
