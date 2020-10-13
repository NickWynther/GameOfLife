using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public interface IRules
    {
        State CalculateNextState(State currentState, int aliveNeighbourCount);
    }
}
