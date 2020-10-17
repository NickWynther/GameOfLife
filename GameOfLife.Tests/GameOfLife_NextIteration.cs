using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameOfLife.Tests
{
    public class GameOfLife_NextIteration
    {
        [Fact]
        public void CalculateNextGeneration_works()
        {
            var sut = new GameOfLife(new GridSize(10,10)); // game with 10x10=100 cells on grid
            var rules = new Mock<IRules>();
            rules.Setup(r => r.CalculateNextState(It.IsAny<State>(), It.IsAny<int>())).Returns(State.Alive);

            sut.CalculateNextGeneration(rules.Object);
            
            //calculateNextState method invoked for every cell 
            rules.Verify(r => r.CalculateNextState(It.IsAny<State>(), It.IsAny<int>()), Times.Exactly(100));
        }
    }
}
