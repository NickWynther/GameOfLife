using FluentAssertions;
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
        public void CalculateNextGeneration_forNewGrid_works()
        {
            var sut = new GameOfLife(new GridSize(10,10)); // game with 10x10=100 cells on grid
            var rules = new Mock<IRules>();
            rules.Setup(r => r.CalculateNextState(It.IsAny<State>(), It.IsAny<int>())).Returns(State.Alive);

            sut.NextIteration(rules.Object);
            
            //calculateNextState method invoked for every cell 
            rules.Verify(r => r.CalculateNextState(It.IsAny<State>(), It.IsAny<int>()), Times.Exactly(100));
        }

        [Fact]
        public void CalculateNextGeneration_predefinedShapeOscillatorBlinker_works()
        {
            int[,] valueMatrix = {{ 0, 1, 0 }, 
                                  { 0, 1, 0 }, 
                                  { 0, 1, 0 }};

            int[,] expected = {{ 0, 0, 0 },
                               { 1, 1, 1 },
                               { 0, 0, 0 }};

            var sut = new GameOfLife(new Grid(valueMatrix));
           
            //act
            sut.NextIteration();
            var result = sut.Grid.GetValueMatrix();

            //assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void CalculateNextGeneration_predefinedShapeSpaceshipGlider_works()
        {
            int[,] valueMatrix = {{ 0, 1, 0 },
                                  { 0, 0, 1 },
                                  { 1, 1, 1 },
                                  { 0, 0, 0 }};

            int[,] expected = {{ 0, 0, 0 },
                               { 0, 0, 1 },
                               { 1, 0, 1 },
                               { 0, 1, 1 }};

            var sut = new GameOfLife(new Grid(valueMatrix));

            //act
            sut.NextIteration();
            sut.NextIteration();
            var result = sut.Grid.GetValueMatrix();

            //assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
