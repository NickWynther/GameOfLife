using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public interface IGameRepository : IEnumerable<GameOfLife>
    {
        /// <summary>
        /// Get total sum of alive cells from all games
        /// </summary>
        public int TotalAliveCells();

        /// <summary>
        /// Add a game to the repository.
        /// </summary>
        public void Add(GameOfLife game);

        /// <summary>
        /// Add many games to the repository. (Concatinate repositories)
        /// </summary>
        public void Add(IGameRepository games);

        /// <summary>
        /// Removes all games from repository.
        /// </summary>
        public void Clear();

        /// <summary>
        /// Gets number of games contained in repository.
        /// </summary>
        /// <returns></returns>
        public int Count();

        /// <summary>
        /// Removes game with provided id from repository.
        /// </summary>
        public void Remove(int id);

        /// <summary>
        /// Gets game with provided id.
        /// </summary>
        public GameOfLife Get(int id);

    }
}
