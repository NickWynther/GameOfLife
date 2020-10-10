using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GameOfLife
{
    /// <summary>
    /// This class is 'Game of life' logical core. 
    /// </summary>
    [Serializable]
    public class GameOfLife
    {
        private static int _idCounter = 1;
        public int Id { get; private set; }
        public Grid Grid { get; set; } //Field of cells
        public uint IterationNumber { get; private set; } = 0;

        public GameOfLife(uint rowsCount , uint columnCount)
        {
            Grid = new Grid(rowsCount,columnCount);
            Id = _idCounter++;
        }

        [OnDeserialized]
        public void CreateId(StreamingContext context)
        {
            Id = _idCounter++;
        }


        /// <summary>
        /// Show current generation of cells.
        /// And compute next generation.  
        /// </summary>
        public void NextIteration() 
        {
            CalculateNextGeneration();
            //UpdateGrid();
            Grid.Update();
            IterationNumber++;
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
    }
}
