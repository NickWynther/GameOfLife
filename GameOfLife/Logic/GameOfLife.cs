using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    /// <summary>
    /// This class is 'Game of life' logical core. 
    /// </summary>
    [Serializable]
    public class GameOfLife
    {
        public Grid Grid { get; set; } //Field of cells
        public IGameView OuputView { get; set; } //Game output (ex. ConsoleView)

        private uint _iterationNumber = 0;

        public GameOfLife(uint rowsCount , uint columnCount , IGameView viewOutput)
        {
            Grid = new Grid(rowsCount,columnCount);
            OuputView = viewOutput;
        }

        /// <summary>
        /// Show current generation of cells.
        /// And compute next generation.  
        /// </summary>
        public void NextIteration() 
        {
            OuputView.ShowGrid(Grid , _iterationNumber);
            CalculateNextGeneration();
            UpdateGrid();
            _iterationNumber++;
        }

        /// <summary>
        /// Calculate new states for each cell.
        /// </summary>
        private void CalculateNextGeneration()
        {
            for (int row = 0; row < Grid.RowsCount; row++)
            {
                for (int column = 0; column < Grid.ColumnCount; column++)
                {
                    int aliveNeighbourCount = Grid.AliveNeighbourCount(row, column);
                    Grid[row, column].CalculateNextState(aliveNeighbourCount);
                }
            }
        }

        /// <summary>
        /// Apply new calculated states to cells.
        /// </summary>
        private void UpdateGrid()
        {
            foreach (Cell cell in Grid)
            {
                cell.Update();
            }
        }
    }
}
