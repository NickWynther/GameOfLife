using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public interface ISizeReader
    {
        /// <summary>
        /// Get size for new grid instance creating.
        /// </summary>
        public void GetSize(out uint rows, out uint column);
    }
}
