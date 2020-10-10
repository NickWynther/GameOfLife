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
                ConsoleKey.N => MenuCommand.NewGame,
                ConsoleKey.L => MenuCommand.LoadFromFile,
                ConsoleKey.P => MenuCommand.PauseExecution,
                ConsoleKey.R => MenuCommand.ResumeExecution,
                ConsoleKey.S => MenuCommand.SaveToFile,
                ConsoleKey.Escape => MenuCommand.Exit,
                ConsoleKey.A => MenuCommand.AddToScreen,
                ConsoleKey.Z => MenuCommand.HideFromScreen,
                ConsoleKey.V => MenuCommand.AddEightToScreen,
                ConsoleKey.M => MenuCommand.ThousandNewGames,
                _ => MenuCommand.Empty
            };
        }
    }
}
