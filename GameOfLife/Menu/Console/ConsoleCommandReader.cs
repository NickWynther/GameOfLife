using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    /// <summary>
    /// Console implementation of ICommandReader interface.
    /// </summary>
    class ConsoleCommandReader : ICommandReader
    {
        /// <summary>
        /// Get MenuCommand enum instance according to pressed key in console.
        /// </summary>
        public MenuCommand GetCommandFromPlayer()
        {
            var comandKey = Console.ReadKey();      
            return comandKey.Key switch
            {
                ConsoleKey.N => MenuCommand.New,
                ConsoleKey.L => MenuCommand.Load,
                ConsoleKey.P => MenuCommand.PauseResume,
                ConsoleKey.S => MenuCommand.Save,
                ConsoleKey.E => MenuCommand.Exit,
                _ => MenuCommand.Empty
            };
        }
    }
}
