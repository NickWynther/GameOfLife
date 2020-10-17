using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{

    /// <summary>
    /// Represent grid size. Count of rows and colums
    /// </summary>
    public class GridSize
    {
        public GridSize(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
        }

        public int Rows { get; set; }
        public int Columns { get; set; }
    }
}
