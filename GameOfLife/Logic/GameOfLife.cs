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

        /// <summary>
        /// When game is loaded from storage, this callback method create new id.
        /// </summary>
        /// <param name="context">Parameter is required by delegat signature.
        /// Describes the source and destination of given serialized stream.
        /// </param>
        [OnDeserialized]
        public void CreateId(StreamingContext context)
        {
            Id = _idCounter++;
        }

        /// <summary>
        /// Basic iteration for particular game:
        ///Calculate next generation.  
        ///Update all cells on grid.
        /// </summary>
        public void NextIteration() 
        {
            CalculateNextGeneration();
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
