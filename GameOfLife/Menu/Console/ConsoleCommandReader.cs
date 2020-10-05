using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.GameMenu
{
    class ConsoleCommandReader : ICommandReader
    {
        public MenuCommand GetCommandFromPlayer()
        {
            var comandKey = Console.ReadKey();

            switch (comandKey.Key)
            {
                case ConsoleKey.N: return MenuCommand.New;
                case ConsoleKey.L: return MenuCommand.Load;
                case ConsoleKey.P: return MenuCommand.PauseResume;
                case ConsoleKey.S: return MenuCommand.Save;
                case ConsoleKey.E: return MenuCommand.Exit;
            }
            return MenuCommand.Empty;
        }
    }
}
