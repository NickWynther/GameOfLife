using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;

namespace GameOfLife
{
    [Serializable]

    //Particular cell on the game field 
    public class Cell 
    {
        public Cell()
        {
           
        }

        public State CurrentState { get; set; } = State.Dead;
        public State NextState { get; set; }

        //Set current cell to random state 
        public void Randomize()
        {
            //Approximately: 20% dead 80% alive  
            CurrentState = (RandomNumberGenerator.GetInt32(0, 5) > 0) ? State.Dead : State.Alive;
        }

        //Cell state in the next generation depends on count of alive neighbours
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

        //Set new calculated status 
        public void Update()
        {
            CurrentState = NextState;
        }

    }
}
