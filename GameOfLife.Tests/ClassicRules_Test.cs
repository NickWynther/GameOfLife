using FluentAssertions;
using System;
using Xunit;

namespace GameOfLife.Tests
{
    public class ClassicRules_CalculateNextState
    {
        [Theory]
        [InlineData(State.Dead,  0, State.Dead)]
        [InlineData(State.Dead,  1, State.Dead)]
        [InlineData(State.Dead,  4, State.Dead)]
        [InlineData(State.Alive, 0, State.Dead)]
        [InlineData(State.Alive, 1, State.Dead)]
        [InlineData(State.Alive, 4, State.Dead)]
        [InlineData(State.Dead,  2, State.Dead)]
        [InlineData(State.Alive, 2, State.Alive)]
        [InlineData(State.Alive, 3, State.Alive)]
        [InlineData(State.Dead,  3, State.Alive)]
        public void CalculateNextState_input_returnExpected(State currentState, int aliveNeighbourCount  , State expected)
        {
            //arrange
            IRules _sut = new ClassicRules();
            //act
            var result = _sut.CalculateNextState(currentState, aliveNeighbourCount);
            //assert
            result.Should().Be(expected);
        }
    }
}
