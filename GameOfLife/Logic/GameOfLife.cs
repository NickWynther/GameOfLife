using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GameOfLife
{
    /// <summary>
    /// This class is 'Game of life' logical core. 
    /// </summary>
    [Serializable]
    public class GameOfLife
    {
        private static int _idCounter = 1;
        public int Id { get; private set; }
        public Grid Grid { get; set; } //Field of cells
        [JsonProperty]
        public uint IterationNumber { get; private set; } = 0;

        /// <summary>
        /// Create new game.
        /// </summary>
        public GameOfLife(GridSize size)
        {
            Grid = new Grid(size);
            Id = _idCounter++;
        }

        /// <summary>
        /// Create new game for existing grid.
        /// </summary>
        public GameOfLife(Grid grid)
        {
            Grid = grid;
            Id = _idCounter++;
        }

        /// <summary>
        /// Constructor for deserealization.
        /// </summary>
        public GameOfLife()
        {

        }

        /// <summary>
        /// When game is loaded from storage, this callback method create new id.
        /// </summary>
        /// <param name="context">Parameter is required by delegat signature.
        /// Describes the source and destination of given serialized stream.
        /// </param>
        [OnDeserialized]
        public void CreateId(StreamingContext context)
        {
            Id = _idCounter++;
            Grid.SetNeighbours();
        }

        /// <summary>
        /// Basic iteration for particular game:
        ///Calculate next generation.  
        ///Update all cells on grid.
        /// </summary>
        /// <param name="rules">'Game of life' rules implementation</param>
        public void NextIteration(IRules rules) 
        {
            CalculateNextGeneration(rules);
            Grid.Update();
            IterationNumber++;
        }


        /// <summary>
        /// Basic iteration for particular game:
        /// Calculate next generation.  
        /// Update all cells on grid.
        /// (Classic rules are used)
        /// </summary>
        public void NextIteration()
        {
            IRules rules = new ClassicRules();
            NextIteration(rules);
        }

        /// <summary>
        /// Calculate new states for each cell. Using specified rules.
        /// </summary>
        private void CalculateNextGeneration(IRules rules)
        {
            foreach (Cell cell in Grid)
            {
                cell.CalculateNextState(rules);
            }
        }
    }
}
