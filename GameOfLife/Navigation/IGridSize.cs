using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    interface IGridSize
    {
        (uint rows, uint column) GetSize();
    }
}
