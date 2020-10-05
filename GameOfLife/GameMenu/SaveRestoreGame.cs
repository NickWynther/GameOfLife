using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
//using System.Text.Json;
using Newtonsoft.Json;

namespace GameOfLife
{
    public class SaveRestoreGame
    {
        public static void SaveDataToFile(GameOfLife game)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("GameOfLife.txt", FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, game);
            stream.Close();
        }

        public static GameOfLife RestoreDataFromFile()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("GameOfLife.txt", FileMode.Open, FileAccess.Read);
            GameOfLife game = (GameOfLife)formatter.Deserialize(stream);
            return game;
        }
        
    }
}
