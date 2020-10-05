using System;
using System.Threading;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {


            ConsoleMenu menu = new ConsoleMenu();
            while (true) 
            {
                menu.Show();
                var cmd = menu.GetCommand();
                menu.Choose(cmd);
            }

            //Without Menu V1.0
         
            //GameOfLife game = new GameOfLife(15, 30, new ConsoleView());
            //while (true)
            //{
            //    game.NextIteration();
            //    Thread.Sleep(1000);
            //    //Console.ReadKey();
            //}
        }
    }
}
