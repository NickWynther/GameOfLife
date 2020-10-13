using System;
using System.Threading;

namespace GameOfLife
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //setup game menu
            var menu = new Menu(
                new ConsoleView(),
                new ConsoleSizeReader(),
                new ConsoleCommandReader(),
                new ConsoleGameSelector(),
                new GameBinarySave());
            //start menu 
            menu.Run();
        }
    }
}
