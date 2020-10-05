using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public interface ISaveManager
    {
        public void Save(GameOfLife gameOfLife);
        public GameOfLife Load();
    }
}
