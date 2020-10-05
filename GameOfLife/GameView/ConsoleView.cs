using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    [Serializable]
    public class ConsoleView : IGameView
    {
        private string _alive = "■ ";
        private string  _dead = "_ ";
        public void Show(Grid grid, uint iterationNumber)
        {
            Console.Clear();
            string currentCell;

            for (int row = 0; row < grid.RowsCount; row++)
            {
                for (int column = 0; column < grid.ColumnCount; column++)
                {
                    if (grid[row,column].CurrentState == State.Alive)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        currentCell = _alive;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        currentCell = _dead;
                    }
                    Console.Write(currentCell);
                }
                Console.Write('\n');
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Iteration number: {iterationNumber}");
            Console.WriteLine($"Live cells: {grid.AliveCellsCount()}");
        }
    }
}
