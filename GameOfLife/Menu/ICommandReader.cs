using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public interface ICommandReader
    {
        MenuCommand GetCommandFromPlayer();
    }
}
