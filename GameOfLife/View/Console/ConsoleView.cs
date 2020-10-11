using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{

    /// <summary>
    /// Game output, console implementation.
    /// </summary>
    public class ConsoleView : IGameView
    {
        //characters representing states
        private string _alive = "■ ";
        private string  _dead = "_ ";
        
        /// <summary>
        /// Show particular game grid in console window.
        /// And particular game statistic.
        /// </summary>
        /// <param name="game">Game to show.</param>
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

        /// <summary>
        /// Show console menu commands.
        /// </summary>
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

        /// <summary>
        /// Show statistic for all running games.
        /// </summary>
        /// <param name="gameCount">Count or running games.</param>
        /// <param name="totalCells">Total count of alive cells in all games.</param>
        public void ShowStatistic(int gameCount, int totalCells)
        {
            Console.WriteLine($"GAMES COUNT: {gameCount}");
            Console.WriteLine($"TOTAL LIVE CELLS: {totalCells}");
        }

        /// <summary>
        /// Clear information from console window.
        /// </summary>
        public void Clear()
        {
            Console.Clear();
        }

        /// <summary>
        /// Show exception message in console.
        /// </summary>
        /// <param name="ex">Exception</param>
        public void ShowException(Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Select [Command] to continue.");
        }
    }
}
