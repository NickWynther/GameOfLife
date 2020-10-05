using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.GameMenu
{
    class ConsoleCommandReader : ICommandReader
    {
        public MenuChoice GetCommandFromPlayer()
        {
            var comandKey = Console.ReadKey();

            switch (comandKey.Key)
            {
                case ConsoleKey.N: return MenuChoice.New;
                case ConsoleKey.L: return MenuChoice.Load;
                case ConsoleKey.P: return MenuChoice.PauseResume;
                case ConsoleKey.S: return MenuChoice.Save;
                case ConsoleKey.E: return MenuChoice.Exit;
            }
            return MenuChoice.Empty;
        }
    }
}
