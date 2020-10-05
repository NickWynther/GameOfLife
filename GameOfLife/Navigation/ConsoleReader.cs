using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public class ConsoleReader : IGridSize
    {

        public (uint rows, uint column) GetSize()
        {
            var userRawInput = Read();
            BindData(userRawInput , out uint width , out uint height);
            if (!IsValid(width, height))
            {
               
            }

            return (height, width);
        }

        private string[] Read()
        {
            Console.WriteLine("Enter Height: ");
            string width = Console.ReadLine();
            Console.WriteLine("Enter Width: ");
            string height = Console.ReadLine();
            return new string[] { width, height };
        }


        private void BindData(string[] data ,out uint width , out uint height )
        {
            if (data.Length >= 2)
            {

                if (!uint.TryParse(data[0], out width) || !uint.TryParse(data[1], out height))
                {
                    throw new ArgumentException("Incorect Console Input");
                }
            }
            else
            {
                throw new ArgumentException("Incorrect input , waiting for 2 arguments");
            }
            
        }

        private bool IsValid(uint width , uint height)
        {
            return (width > 0 && height > 0);
        }

        
    }
}
