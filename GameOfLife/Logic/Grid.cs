using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace GameOfLife
{
    /// <summary>
    /// Grid represents a rectangle field of cells.
    /// </summary>
    [Serializable]
    public class Grid : IEnumerable
    {
        public uint RowsCount { get;  set; }
        public uint ColumnCount { get; set; }             
        private Cell[,] _cells;

        /// <summary>
        /// Create new grid
        /// </summary>
        /// <param name="rowsCount">Height size.</param>
        /// <param name="columnCount">Width size.</param>
        public Grid(uint rowsCount, uint columnCount)
        {
            RowsCount = rowsCount;
            ColumnCount = columnCount;
            InitializeCells(); 
            Randomize();
        }

        /// <summary>
        /// Initialize two-dimensional _cells array with Cell objects
        /// </summary>
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

        /// <summary>
        /// Set all cells in random state.
        /// </summary>
        public void Randomize()
        {
            foreach(Cell cell in _cells)
            {
                cell.Randomize();
            }
        }

        /// <summary>
        /// Set new states for all cells on grid. (Create next generation.)
        /// </summary>
        public void Update()
        {
            foreach (Cell cell in _cells)
            {
                cell.Update();
            }
        }

        /// <summary>
        /// Get count of all alive cells on the grid.
        /// </summary>
        public int AliveCellsCount()
        {
            int count = 0;
            foreach (Cell cell in _cells)
            {
                count += (cell.CurrentState == State.Alive) ? 1 : 0;
            }
            return count;
        }

        /// <summary>
        /// Check if element with provided index exists on the grid.
        /// </summary>
        /// <returns>True if element exist, False if not exist.</returns>
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

        /// <summary>
        /// Get count of alive neighbour for conrete cell
        /// </summary>
        /// <param name="row">Cell position</param>
        /// <param name="column">Cell position</param>
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

        /// <summary>
        /// Implementation of indexer 
        /// </summary>
        /// <param name="row">Row's index on the grid</param>
        /// <param name="column">Column's index on the grid</param>
        /// <returns>Cell with provided index</returns>
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

        /// <returns>An IEnumerator for grid</returns>
        public IEnumerator GetEnumerator()
        {
            return _cells.GetEnumerator();
        }
    }
}
