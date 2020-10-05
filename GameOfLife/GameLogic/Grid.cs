using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace GameOfLife
{
    [Serializable]
    public class Grid : IEnumerable<Cell>
    {
        public int RowsCount { get;  set; }
        public int ColumnCount { get; set; }
     
        
        public Cell[,] _cells;

        public Grid()
        {

        }

        public Grid(int rowsCount, int columnCount)
        {
            RowsCount = rowsCount;
            ColumnCount = columnCount;
            InitializeCells();

            //
            Randomize();

        }

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

        public void Randomize()
        {
            foreach(Cell cell in _cells)
            {
                cell.Randomize();
            }
        }

        public int AliveCellsCount()
        {
            int count = 0;
            foreach (Cell cell in _cells)
            {
                count += (cell.CurrentState == State.Alive) ? 1 : 0;
            }
            return count;
        }

        

        public int AliveNeighbourCount(int row, int column)
        {
            bool NeighbourIndexExist(int row, int column)
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

            var aliveNeighbourCount = 0;

            for (var i = row -1; i <= row+1; i++)
            {
                for (var j = column -1; j <= column+1; j++)
                {
                    //SKIP, because target cell is not a neighbour for itself 
                    // OR Index out of bounds
                    if (i == row && j == column || !NeighbourIndexExist(i,j) )
                    {
                        continue;
                    }

                    aliveNeighbourCount += _cells[i , j].CurrentState == State.Alive ? 1 : 0;
                }
            }
           
            return aliveNeighbourCount;
        }


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
