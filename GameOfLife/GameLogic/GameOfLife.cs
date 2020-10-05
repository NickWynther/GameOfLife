using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    [Serializable]
    public class GameOfLife
    {
        public Grid Grid { get; set; }
        public IGameView OuputView { get; set; }

        private uint _iterationNumber = 0;

        public GameOfLife(int rowsCount , int columnCount , IGameView viewOutput)
        {
            Grid = new Grid(rowsCount,columnCount);
            OuputView = viewOutput;
        }

        public void NextIteration()
        {
            OuputView.Show(Grid , _iterationNumber);
            CalculateNextGeneration();
            UpdateGrid();
            _iterationNumber++;
        }


        //Calculate new state for each cell (excluding borders)
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

        //Apply calculated states to cells
        private void UpdateGrid()
        {
            foreach (Cell cell in Grid)
            {
                cell.Update();
            }
        }

    }
}
