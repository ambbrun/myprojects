using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;

namespace ConwaysGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Application(new GameRunner(new LifeAnalyzer()));
            app.Run();
        }
    }
}
