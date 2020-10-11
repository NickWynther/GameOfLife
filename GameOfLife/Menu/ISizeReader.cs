using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    /// <summary>
    /// Provide to player functionality to selct game size
    /// </summary>
    public interface ISizeReader
    {
        /// <summary>
        /// Get size for new grid instance creating.
        /// </summary>
        public void GetSize(out uint rows, out uint column);
    }
}
