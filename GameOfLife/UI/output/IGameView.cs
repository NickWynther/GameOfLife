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
        void ShowGrid(GameOfLife game);

        /// <summary>
        /// Show menu with command list
        /// </summary>
        void ShowMenu();

        /// <summary>
        /// Show statistic for all running games.
        /// </summary>
        /// <param name="gameCount">Count or running games.</param>
        /// <param name="totalCells">Total count of alive cells in all games.</param>
        void ShowStatistic(int gameCount, int totalCells);

        /// <summary>
        /// Clear game window
        /// </summary>
        void ClearScreen();

        /// <summary>
        /// Show exception messages occured during a game process.
        /// </summary>
        /// <param name="ex"></param>
        void ShowException(Exception ex);
    }
}
