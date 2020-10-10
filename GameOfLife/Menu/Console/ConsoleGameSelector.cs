using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    class ConsoleGameSelector : IGameSelector
    {
        public int SelectGame()
        {
            string userInput = Read();
            int index = ParseInput(userInput);
            return index;
        }

        public List<int> SelectGame(int count)
        {
            var idList = new List<int>();
            for (int gameNumber = 1; gameNumber <= count; gameNumber++)
            {
                string userInput = Read(gameNumber);
                int id = ParseInput(userInput);
                idList.Add(id);
            }
            return idList;
        }

        private string Read()
        {
            Console.Write("\nChoose game id> ");
            string id = Console.ReadLine();
            return id;
        }

        private string Read(int number)
        {
            Console.WriteLine($"Choose {number}.game id> ");
            string id = Console.ReadLine();
            return id;
        }

        private int ParseInput(string data)
        {
            if (!int.TryParse(data, out int id))
            {
                throw new ArgumentException("Incorect Console Input");
            }
            return id;
        }

      
    }
}
