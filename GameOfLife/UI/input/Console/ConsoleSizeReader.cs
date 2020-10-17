using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    /// <summary>
    /// Console implementation of ISizeReader.
    /// </summary>
    public class ConsoleSizeReader : ISizeReader
    {

        /// <summary>
        /// Get grid size from user throught console.
        /// </summary>
        public GridSize GetGridSize()
        {
            var playerInput = Read();
            BindData(playerInput, out int rows, out int columns);
            Validate(rows, columns);
            return new GridSize(rows, columns);
        }

        /// <summary>
        /// Ask player to pass count of rows and columns.
        /// </summary>
        /// <returns>Array with two strings provided by user.</returns>
        private string[] Read()
        {
            Console.Write("\nEnter Height> ");
            string width = Console.ReadLine();
            Console.Write("Enter Width> ");
            string height = Console.ReadLine();
            return new string[] { width, height };
        }

        /// <summary>
        /// Parse user input as unsigned integers.
        /// If input is incorrect, throw ArgumnetException.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private void BindData(string[] data ,out int width , out int height )
        {
            if (data.Length >= 2)
            {
                if (!int.TryParse(data[0], out width) || !int.TryParse(data[1], out height))
                {
                    throw new ArgumentException("Incorect Console Input");
                }
            }
            else
            {
                throw new ArgumentException("Incorrect input , waiting for 2 arguments");
            }
        }

        /// <summary>
        /// Validate user input. Count of coulms and rows should be positive.
        /// If not, throw ArgumnetException.
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        private void Validate(int rows , int columns)
        {
            if (rows < 1 || columns < 1)
            {
                throw new ArgumentException("Argumnents should be positive");
            }
        }
    }
}
