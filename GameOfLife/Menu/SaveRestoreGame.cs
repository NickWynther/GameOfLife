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
        //problems here
        public static void SaveDataToFile(GameOfLife game)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("GameOfLife.txt", FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, game);
            stream.Close();

            //// serialize JSON directly to a file
            //using (StreamWriter file = File.CreateText("GameOfLife.gof"))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    serializer.Serialize(file, game);
            //}
        }

        public static GameOfLife RestoreDataFromFile()
        {

            //// deserialize JSON directly from a file
            //using (StreamReader file = File.OpenText("GameOfLife.gof"))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    return (GameOfLife)serializer.Deserialize(file, typeof(GameOfLife));
            //}

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("GameOfLife.txt", FileMode.Open, FileAccess.Read);
            GameOfLife game = (GameOfLife)formatter.Deserialize(stream);
            return game;

        }
        
    }
}
