using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    /// <summary>
    /// Basic game collection. List wrapper.
    /// </summary>
    [Serializable]
    [JsonObject]
    public class GameRepository : IGameRepository
    {
        [JsonProperty]
        private List<GameOfLife> _games;

        /// <summary>
        /// Create new repository.
        /// </summary>
        public GameRepository()
        {
            _games = new List<GameOfLife>();
        }

        /// <summary>
        /// Get total sum of alive cells from all games
        /// </summary>
        public int TotalAliveCells()
        {
            int total = 0;
            foreach (var game in _games)
            {
                total += game.Grid.AliveCellsCount();
            }
            return total;
        }

        /// <summary>
        /// Add a game to the repository.
        /// </summary>
        public void Add(GameOfLife game) => _games.Add(game);

        /// <summary>
        /// Add many games to the repository. (Concatinate repositories)
        /// </summary>
        public void Add(IGameRepository games) => games.ToList().ForEach(game => Add(game));


        /// <summary>
        /// Removes all games from repository.
        /// </summary>
        public void Clear() => _games.Clear();

        /// <summary>
        /// Gets number of games contained in repository.
        /// </summary>
        /// <returns></returns>
        public int Count() => _games.Count;

        /// <summary>
        /// Removes game with provided id from repository.
        /// If no game founded, throw ArgumentException.
        /// </summary>
        public void Remove(int id)
        {
            if (_games.Exists(game => game.Id == id)) 
            { 
                _games.RemoveAll(game => game.Id == id);
            }
            else
            {
                throw new ArgumentException("Incorrect game id.");
            }
        }

        /// <summary>
        /// Gets game with provided id.
        /// If no game founded, throw ArgumentException.
        /// </summary>
        public GameOfLife Get(int id) 
        {
            try
            {
                return _games.Single(game => game.Id == id);
            }
            catch
            {
                throw new ArgumentException("Incorrect game id.");
            }
        }

        public IEnumerator<GameOfLife> GetEnumerator() => _games.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
