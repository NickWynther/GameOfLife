using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public interface IGameSelector 
    {
        int SelectGame();
        List<int> SelectGame(int count);
    }
}
