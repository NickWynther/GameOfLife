using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Menu
{
    interface ICommandReader
    {
        MenuChoice GetCommandFromPlayer();
    }
}
