using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public interface ISizeReader
    {
        //Get grid size for new instance creating
         public void GetSize(out uint rows, out uint column);
    }
}
