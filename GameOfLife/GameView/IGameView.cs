using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public interface IGameView
    {
        public void Show(Grid grid , uint iterationNumber);
    }
}
