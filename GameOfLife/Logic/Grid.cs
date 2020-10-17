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
        public GridSize Size { get; set; }

        [JsonProperty]
        private Cell[,] _cells;
        
        /// <summary>
        /// Basic constructor. Fill with random values.
        /// </summary>
        /// <param name="rowsCount">Height size.</param>
        /// <param name="columnCount">Width size.</param>
        public Grid(GridSize size)
        {
            Size = size;
            InitializeGrid();
            SetNeighbours();
            Randomize();
        }

        /// <summary>
        /// Fill grid with values from binary matrix.
        /// </summary>
        /// <param name="matrix">Matrix with cell values</param>
        public Grid(int[,] matrix)
        {
            Size = new(matrix.GetLength(0), matrix.GetLength(1));
            InitializeGrid(matrix);
            SetNeighbours();
        }

        /// <summary>
        /// Constructor for deserialization.
        /// </summary>
        public Grid()
        {

        }

        /// <summary>
        /// Initialize two-dimensional _cells array with Cell objects.
        /// </summary>
        private void InitializeGrid()
        {
            _cells = new Cell[Size.Rows, Size.Columns];
            for (int row = 0; row < Size.Rows; row++)
            {
                for (int column = 0; column < Size.Columns; column++)
                {
                    _cells[row, column] = new();
                }
            }
        }

        /// <summary>
        /// Initialize two-dimensional _cells array with Cell objects.
        /// And set values from matrix.
        /// </summary>
        private void InitializeGrid(int[,] matrix)
        {
            _cells = new Cell[Size.Rows, Size.Columns];
            for (int row = 0; row < Size.Rows; row++)
            {
                for (int column = 0; column < Size.Columns; column++)
                {
                    _cells[row, column] = new Cell { 
                        CurrentState=(State)matrix[row,column] 
                    };
                }
            }
        }


        /// <summary>
        /// Get binary matrix with values from grid
        /// </summary>
        /// <returns></returns>
        public int[,] GetValueMatrix()
        {
            int[,] matrix = new int[Size.Rows, Size.Columns];
            for (int row = 0; row < Size.Rows; row++)
            {
                for (int column = 0; column < Size.Columns; column++)
                {
                    matrix[row, column] = (int)_cells[row, column].CurrentState;
                }
            }

            return matrix;
        }

        /// <summary>
        /// Set list of neighbours for each cell
        /// </summary>
        public void SetNeighbours()
        {
            for (int row = 0; row <Size.Rows; row++)
            {
                for (int column = 0; column < Size.Columns; column++)
                {
                    _cells[row, column].Neighbours = GetNeighbourList(row, column);
                }
            }
        }

        /// <summary>
        /// Set all cells in random state.
        /// </summary>
        private void Randomize()
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
            if (row <0 || row >= Size.Rows)
            {
                return false;
            }

            if (column <0 || column >= Size.Columns)
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
