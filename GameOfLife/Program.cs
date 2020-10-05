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
                new GameBinarySave());
            menu.Start();
        }

        private static void WithoutMenu()
        {
            GameOfLife game = new GameOfLife(15, 30, new ConsoleView());
            while (true)
            {
                game.NextIteration();
                Thread.Sleep(1000);
                //Console.ReadKey();
            }
        }
    }
}
