using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public interface IGameView
    {
        public void ShowGrid(Grid grid , uint iterationNumber);
        public void ShowMenu();
    }
}
