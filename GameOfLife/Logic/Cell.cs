using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace GameOfLife
{
    /// <summary>
    ///  Particular cell on the game grid. 
    /// </summary>
    [Serializable]
    public class Cell 
    {
        [JsonIgnore]
        public List<Cell> Neighbours { get; set; } 
        public State CurrentState { get; set; } = State.Dead;
        public State NextState { get; set; }

        /// <summary>
        /// Set current cell to random state.
        /// Approximately 20% chance to become alive (And 80% - dead). 
        /// </summary>
        public void Randomize()
        {
            CurrentState = (RandomNumberGenerator.GetInt32(0, 5) > 0) ? State.Dead : State.Alive;
        }

        /// <summary>
        /// Count of alive neighbour for current cell.
        /// </summary>
        public int AliveNeighbourCount()
        {
            int count = 0;
            foreach (Cell cell in Neighbours)
            {
                count += (cell.CurrentState == State.Alive) ? 1 : 0;
            }
            return count;
        }

        /// <summary>
        /// Calculate cell state in next generation. 
        /// This state depends on count of alive neighbours for current cell.
        /// </summary>
        public void CalculateNextState()
        {
            int aliveNeighbourCount = AliveNeighbourCount();

            if (aliveNeighbourCount < 2 || aliveNeighbourCount > 3)
            {
                NextState = State.Dead;
            }
            else
            {
                NextState = aliveNeighbourCount == 3 ? State.Alive : CurrentState;
            }
        }

        /// <summary>
        /// Set new status for cell. (Apply calculation)
        /// </summary>
        public void Update()
        {
            CurrentState = NextState;
        }
    }
}
