using System;
using System.Threading;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new Menu(
                new ConsoleView(),
                new ConsoleSizeReader(),
                new ConsoleCommandReader(),
                new ConsoleGameSelector(),
                new GameBinarySave());
            menu.Run();
        }
    }
}
