using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public interface ICommandReader
    {
        /// <summary>
        /// Get enum with command chosen by player
        /// </summary>
        MenuCommand GetCommandFromPlayer();
    }
}
