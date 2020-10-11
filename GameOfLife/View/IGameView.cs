using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{

    /// <summary>
    /// Game output window
    /// </summary>
    public interface IGameView
    {

        /// <summary>
        /// Show particular game grid
        /// </summary>
        /// <param name="game">game to show</param>
        public void ShowGrid(GameOfLife game);

        /// <summary>
        /// Show menu with command list
        /// </summary>
        public void ShowMenu();

        /// <summary>
        /// Show statistic for all running games.
        /// </summary>
        /// <param name="gameCount">Count or running games.</param>
        /// <param name="totalCells">Total count of alive cells in all games.</param>
        public void ShowStatistic(int gameCount, int totalCells);

        /// <summary>
        /// Clear game window
        /// </summary>
        public void Clear();

        /// <summary>
        /// Show exception messages occured during a game process.
        /// </summary>
        /// <param name="ex"></param>
        public void ShowException(Exception ex);
    }
}
