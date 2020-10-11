using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{

    /// <summary>
    /// Functionality for getting commands from player.
    /// </summary>
    public interface ICommandReader
    {
        /// <summary>
        /// Get command chosen by player.
        /// </summary>
        /// <returns>Enum instance associated with player chosen command</returns>
        MenuCommand GetCommandFromPlayer();
    }
}
