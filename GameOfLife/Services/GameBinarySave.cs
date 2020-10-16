using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Newtonsoft.Json;

namespace GameOfLife
{
    /// <summary>
    /// Save/Load game in binary format.
    /// </summary>
    public class GameBinarySave : ISaveManager
    {
        private const string _filename = "GameOfLife.txt";
        private const string _repoFilename = "GameOfLifeAll.txt";

        /// <summary>
        /// Save game object in binary format to file.
        /// </summary>
        public void Save(GameOfLife game)
        {
            IFormatter formatter = new BinaryFormatter();
            using Stream stream = new FileStream(_filename, FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, game);
        }

        /// <summary>
        /// Load game object from file.
        /// </summary>
        public GameOfLife Load()
        {
            IFormatter formatter = new BinaryFormatter();
            using Stream stream = new FileStream(_filename, FileMode.Open, FileAccess.Read);
            GameOfLife game = (GameOfLife)formatter.Deserialize(stream);
            return game;
        }

        /// <summary>
        /// Save all games from repository to storage
        /// </summary>
        /// <param name="games"></param>
        public void SaveAll(IGameRepository games)
        {
            IFormatter formatter = new BinaryFormatter();
            using Stream stream = new FileStream(_repoFilename, FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, games);
        }

        /// <summary>
        /// Load all games from file to repository
        /// </summary>
        /// <returns>Deserizalized repository</returns>
        public IGameRepository LoadAll()
        {
            IFormatter formatter = new BinaryFormatter();
            using Stream stream = new FileStream(_repoFilename, FileMode.Open, FileAccess.Read);
            GameRepository gameRepo = (GameRepository)formatter.Deserialize(stream);
            return gameRepo;
        }
    }
}
