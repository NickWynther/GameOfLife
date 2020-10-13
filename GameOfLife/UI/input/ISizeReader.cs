using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    /// <summary>
    /// Functionality to selct game size.
    /// </summary>
    public interface ISizeReader
    {
        /// <summary>
        /// Get size for new grid instance creating.
        /// </summary>
        public void GetGridSize(out uint rows, out uint column);
    }
}
