using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    /// <summary>
    /// User interface. (Input / Output)
    /// </summary>
    public interface IPlayerInterface : ICommandReader , ISizeReader , IGameSelector , IGameView
    {
    }
}
