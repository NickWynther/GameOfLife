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
        public MenuCommand GetCommand()
        {
            var comandKey = Console.ReadKey();      
            return comandKey.Key switch
            {
                ConsoleKey.N => MenuCommand.NewGame,
                ConsoleKey.L => MenuCommand.LoadGame,
                ConsoleKey.P => MenuCommand.PauseExecution,
                ConsoleKey.R => MenuCommand.ResumeExecution,
                ConsoleKey.S => MenuCommand.SaveGame,
                ConsoleKey.Escape => MenuCommand.Exit,
                ConsoleKey.A => MenuCommand.AddToScreen,
                ConsoleKey.Z => MenuCommand.HideFromScreen,
                ConsoleKey.V => MenuCommand.AddEightToScreen,
                ConsoleKey.M => MenuCommand.ThousandNewGames,
                ConsoleKey.O => MenuCommand.SaveAllGames,
                ConsoleKey.I => MenuCommand.LoadAllGames,
                _ => throw new NotSupportedException("Incorrect command")
            };
        }
    }
}
