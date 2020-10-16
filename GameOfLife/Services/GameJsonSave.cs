using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace GameOfLife 
{ 
    public class GameJsonSave : ISaveManager
    {
        public string Filename {get; set;} = "GameOfLife.json";
        public string FilenameAll {get; set;} = "AllGamesOfLife.json";

        public GameOfLife Load()
        {
            var json = File.ReadAllText(Filename);
            var game = JsonConvert.DeserializeObject<GameOfLife>(json);
            return game;
        }

        public IGameRepository LoadAll()
        {
            var json = File.ReadAllText(FilenameAll);
            var repo = JsonConvert.DeserializeObject<GameRepository>(json);
            return repo;
        }

        public void Save(GameOfLife gameOfLife)
        {
            var json = JsonConvert.SerializeObject(gameOfLife);
            File.WriteAllText(Filename, json);
        }

        public void SaveAll(IGameRepository games)
        {
            var json = JsonConvert.SerializeObject(games);
            File.WriteAllText(FilenameAll, json);
        }
    }
}
