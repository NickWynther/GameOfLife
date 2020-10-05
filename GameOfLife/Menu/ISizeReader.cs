using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public interface ISizeReader
    {
         public void GetSize(out uint rows, out uint column);
    }
}
