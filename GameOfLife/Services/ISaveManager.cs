using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    /// <summary>
    /// Functionality to save game on storage.
    /// </summary>
    public interface ISaveManager
    {
        /// <summary>
        /// Save game.
        /// </summary>
        /// <param name="gameOfLife">Game to save</param>
        public void Save(GameOfLife gameOfLife);

        /// <summary>
        /// Load game from storage.
        /// </summary>
        /// <returns>Saved game from storage.</returns>
        public GameOfLife Load();

        /// <summary>
        /// Save all running games to storage.
        /// </summary>
        /// <param name="games">Games repository</param>
        public void SaveAll(GameRepository games);

        /// <summary>
        /// Load all games from storage.
        /// </summary>
        /// <returns></returns>
        public GameRepository LoadAll();
    }
}
