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
        
        public void ShowGrid(GameOfLife game)
        {
            string currentCell;
            for (int row = 0; row < game.Grid.RowsCount; row++)
            {
                for (int column = 0; column < game.Grid.ColumnCount; column++)
                {
                    if (game.Grid[row,column].CurrentState == State.Alive)
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"ID:{game.Id}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Iteration number: {game.IterationNumber}");
            Console.WriteLine($"Live cells: {game.Grid.AliveCellsCount()}");
        }

        public void ShowMenu()
        {
            Console.WriteLine("-------Menu-------");
            Console.WriteLine("[N].New");
            Console.WriteLine("[S].Save");
            Console.WriteLine("[L].Load");
            Console.WriteLine("[P].Pause");
            Console.WriteLine("[R].Resume");
            Console.WriteLine("[M].Run 1000 games");
            Console.WriteLine("[A].Add to screen");
            Console.WriteLine("[V].Set 8 games to screen");
            Console.WriteLine("[Z].Remove from screen");
            Console.WriteLine("[esc].Exit");
            Console.WriteLine("------------------");
            Console.Write(">");
        }

        public void ShowStatistic(int gameCount, int totalCells)
        {
            Console.WriteLine($"GAMES COUNT: {gameCount}");
            Console.WriteLine($"TOTAL LIVE CELLS: {totalCells}");
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void ShowException(Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Select [Command] to continue.");
        }
    }
}
