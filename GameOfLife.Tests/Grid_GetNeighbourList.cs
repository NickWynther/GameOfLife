using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameOfLife.Tests
{
    public class Grid_GetNeighbourList
    {
        [Theory]
        [InlineData(0, 0, 3)] //upper left corner
        [InlineData(0, 3, 5)] //upper border
        [InlineData(0, 4, 3)] //upper right corner
        [InlineData(1, 0, 5)] //left border
        [InlineData(1, 4, 5)] //right border
        [InlineData(3, 3, 8)] //center 
        [InlineData(4, 0, 3)] //bottom left corner 
        [InlineData(4, 4, 3)] //bottom right corner 
        [InlineData(4, 3, 5)] //bottom border
        public void GetNeighbourList_input_returnExpected(int row, int column , int expected)
        {
            var sut = new Grid(5, 5);

            var result = sut.GetNeighbourList(row,column);

            result.Should().NotBeEmpty().And.HaveCount(expected);
        }

        [Fact]
        public void CalculateNextState_throwException()
        {
            var sut = new Grid(5, 5);

            Action act = () => sut.GetNeighbourList(100, 100);

            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
