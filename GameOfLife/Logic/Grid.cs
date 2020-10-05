using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace GameOfLife
{
    //Grid represents a rectangle field of cells
    [Serializable]
    public class Grid : IEnumerable<Cell>
    {
        public uint RowsCount { get;  set; }
        public uint ColumnCount { get; set; }             
        private Cell[,] _cells;

        public Grid(uint rowsCount, uint columnCount)
        {
            RowsCount = rowsCount;
            ColumnCount = columnCount;
            InitializeCells(); 
            Randomize();
        }

        //Initialize two-dimensional _cells array with Cell objects
        private void InitializeCells()
        {
            _cells = new Cell[RowsCount, ColumnCount];
            for (int row = 0; row < RowsCount; row++)
            {
                for (int column = 0; column < ColumnCount; column++)
                {
                    _cells[row, column] = new Cell();
                }
            }
        }

        //Set all cells in random state 
        public void Randomize()
        {
            foreach(Cell cell in _cells)
            {
                cell.Randomize();
            }
        }

        //Get count of all alive cells on the grid
        public int AliveCellsCount()
        {
            int count = 0;
            foreach (Cell cell in _cells)
            {
                count += (cell.CurrentState == State.Alive) ? 1 : 0;
            }
            return count;
        }

        //Check if element with provided index exists on the grid
        private bool IndexExist(int row, int column)
        {
            if (row == -1 || row == RowsCount)
            {
                return false;
            }
            if (column == -1 || column == ColumnCount)
            {
                return false;
            }
            return true;
        }

        //Get count of alive neighbour for conrete cell
        public int AliveNeighbourCount(int row, int column)
        {
            var aliveNeighbourCount = 0;

            for (var i = row -1; i <= row+1; i++)
            {
                for (var j = column -1; j <= column+1; j++)
                {
                    //SKIP, because target cell is not a neighbour for itself 
                    // OR Index out of bounds
                    if (i == row && j == column || !IndexExist(i,j) )
                    {
                        continue;
                    }
                    aliveNeighbourCount += _cells[i , j].CurrentState == State.Alive ? 1 : 0;
                }
            }
            return aliveNeighbourCount;
        }
        
        //Implementation of indexer 
        public Cell this[int row , int column]
        {
            get
            {
                return _cells[row, column];
            }
            set
            {
                _cells[row,column] = value;
            }
        }

        #region Implementation of IEnumerable
        public IEnumerator<Cell> GetEnumerator()
        {
            for (int row = 0; row < RowsCount; row++)
            {
                for (int column = 0; column < ColumnCount; column++)
                {
                    yield return this[row, column];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
