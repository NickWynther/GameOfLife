using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;
using Newtonsoft.Json;

namespace GameOfLife
{
    /// <summary>
    /// Grid represents a rectangle field of cells.
    /// </summary>
    [Serializable]
    [JsonObject]
    public class Grid : IEnumerable 
    {
        public uint RowsCount { get;  set; }
        public uint ColumnCount { get; set; }

        [JsonProperty]
        private Cell[,] _cells;
        
        /// <summary>
        /// Basic constructor.
        /// </summary>
        /// <param name="rowsCount">Height size.</param>
        /// <param name="columnCount">Width size.</param>
        public Grid(uint rowsCount, uint columnCount)
        {
            RowsCount = rowsCount;
            ColumnCount = columnCount;
            InitializeGrid();
            SetNeighbours();
            Randomize();
        }

        /// <summary>
        /// Constructor for deserialization.
        /// </summary>
        public Grid()
        {
        }

        /// <summary>
        /// Initialize two-dimensional _cells array with Cell objects
        /// </summary>
        private void InitializeGrid()
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
        /// Set list of neighbours for each cell
        /// </summary>
        public void SetNeighbours()
        {
            for (int row = 0; row < RowsCount; row++)
            {
                for (int column = 0; column < ColumnCount; column++)
                {
                    _cells[row, column].Neighbours = GetNeighbourList(row, column);
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
            if (row <0 || row >= RowsCount)
            {
                return false;
            }
            if (column <0 || column >= ColumnCount)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Get list of neigbour cells for particular cell
        /// </summary>
        /// <returns>List of neighbour cells</returns>
        public List<Cell> GetNeighbourList(int row, int column)
        {
            if (!IndexExist(row, column))
            {
                throw new ArgumentOutOfRangeException();
            }

            var neighbours = new List<Cell>();

            for (var i = row - 1; i <= row + 1; i++)
            {
                for (var j = column - 1; j <= column + 1; j++)
                {
                    //SKIP, because target cell is not a neighbour for itself 
                    // OR Index out of bounds
                    if (i == row && j == column || !IndexExist(i, j))
                    {
                        continue;
                    }
                    neighbours.Add(_cells[i, j]);
                }
            }
            return neighbours;
        }

        /// <summary>
        /// Implementation of indexer 
        /// </summary>
        /// <param name="row">Row's index on the grid</param>
        /// <param name="column">Column's index on the grid</param>
        /// <returns>Cell with provided index</returns>
        public Cell this[int row, int column]
        {
            get
            {
                return _cells[row, column];
            }
            set
            {
                _cells[row, column] = value;
            }
        }

        /// <returns>An IEnumerator for grid</returns>
        public IEnumerator GetEnumerator()
        {
            return _cells.GetEnumerator();
        }
    }
}
