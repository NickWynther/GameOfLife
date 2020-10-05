using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.GameMenu
{
    public interface ICommandReader
    {
        MenuChoice GetCommandFromPlayer();
    }
}
