using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    /// <summary>
    /// Implementation of "Game of Life" classic rules
    /// </summary>
    public class ClassicRules : IRules
    {
        /// <summary>
        /// Calculate next state for cell depending on rules.
        /// </summary>
        /// <param name="currentState">Cell current state.</param>
        /// <param name="aliveNeighbourCount">Cell alive neighbours count.</param>
        /// <returns></returns>
        public State CalculateNextState(State currentState, int aliveNeighbourCount)
        {
            if (aliveNeighbourCount < 2 || aliveNeighbourCount > 3)
            {
                return State.Dead;
            }
            else
            {
                return aliveNeighbourCount == 3 ? State.Alive : currentState;
            }
        }
    }
}
