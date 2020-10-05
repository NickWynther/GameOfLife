using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public class ConsoleSizeReader : ISizeReader
    {
        public void GetSize(out uint rows, out uint columns)
        {
            var playerInput = Read();
            BindData(playerInput, out rows, out columns);
            Validate(rows, columns);
        }


        private string[] Read()
        {
            Console.Write("\nEnter Height: ");
            string width = Console.ReadLine();
            Console.Write("Enter Width: ");
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

        private void Validate(uint rows , uint columns)
        {
            if (rows < 1 || columns < 1)
            {
                throw new ArgumentException("Argumnents should be positive");
            }
        }

        
    }
}
