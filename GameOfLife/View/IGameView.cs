using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public interface IGameView
    {
        public void ShowGrid(GameOfLife game);
        public void ShowMenu();
        public void ShowStatistic(int gameCount, int totalCells);
        public void Clear();
        public void ShowException(Exception ex);
    }
}
