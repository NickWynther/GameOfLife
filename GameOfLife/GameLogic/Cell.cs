using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;

namespace GameOfLife
{
    [Serializable]
    public class Cell
    {
        public Cell()
        {
           
        }

        public State CurrentState { get; set; } = State.Dead;
        public State NextState { get; set; }

        public void Randomize()
        {
            //CurrentState = (State)RandomNumberGenerator.GetInt32(0, 2);

            CurrentState = (RandomNumberGenerator.GetInt32(0, 5) > 0) ? State.Dead : State.Alive;

        }

        public void CalculateNextState(int aliveNeighbourCount)
        {
            if (aliveNeighbourCount< 2 || aliveNeighbourCount> 3)
            {
                NextState = State.Dead;
            }
            else
            {
                NextState = aliveNeighbourCount == 3 ? State.Alive : CurrentState;
            }
        }

        public void Update()
        {
            CurrentState = NextState;
        }

    }
}
