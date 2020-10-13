using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    /// <summary>
    /// Functionality to select game id throught console.
    /// </summary>
    class ConsoleGameSelector : IGameSelector
    {
        /// <summary>
        /// Ask player to input game id, parse it and return.
        /// </summary>
        /// <returns>Selected game id</returns>
        public int SelectGame()
        {
            string userInput = Read();
            int index = ParseInput(userInput);
            return index;
        }

        /// <summary>
        /// Ask player to input game id n-times, parse it and return list of ids.
        /// </summary>
        /// <returns>List of selected games id</returns>
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

        /// <summary>
        /// Ask palyer to input game id
        /// </summary>
        /// <returns>string with palyer raw input</returns>
        private string Read()
        {
            Console.Write("\nChoose game id> ");
            string id = Console.ReadLine();
            return id;
        }

        /// <summary>
        /// Ask palyer to input id for n-th game. 
        /// </summary>
        /// <param name="number">Game numer</param>
        /// <returns>string with palyer raw input</returns>
        private string Read(int number)
        {
            Console.WriteLine($"Choose {number}.game id> ");
            string id = Console.ReadLine();
            return id;
        }

        /// <summary>
        /// Parse user input to integer.
        /// If not successful, throw new ArgumentException
        /// </summary>
        /// <param name="data">Raw palyer input.</param>
        /// <returns>Parsed integer.</returns>
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
