using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    /// <summary>
    /// Provide to player functionality to selct game  
    /// </summary>
    public interface IGameSelector 
    {
        /// <summary>
        /// Select game id
        /// </summary>
        /// <returns>game id.</returns>
        int SelectGame();

        /// <summary>
        /// Select many games id
        /// </summary>
        /// <param name="count">How many game ids to selct</param>
        /// <returns>List of ids for selected games</returns>
        List<int> SelectGame(int count);
    }
}
