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
        [InlineData(5, 0, 0, 3)] //upper left corner
        [InlineData(5, 0, 3, 5)] //upper border
        [InlineData(5, 0, 4, 3)] //upper right corner
        [InlineData(5, 1, 0, 5)] //left border
        [InlineData(5, 1, 4, 5)] //right border
        [InlineData(5, 3, 3, 8)] //center 
        [InlineData(5, 4, 0, 3)] //bottom left corner 
        [InlineData(5, 4, 4, 3)] //bottom right corner 
        [InlineData(5, 4, 3, 5)] //bottom border
        public void GetNeighbourList_input_returnExpected(int squareSize, int row, int column , int expected)
        {
            var sut = new Grid(new GridSize(squareSize, squareSize));

            var result = sut.GetNeighbourList(row,column);

            result.Should().NotBeEmpty().And.HaveCount(expected);
        }

        [Fact]
        public void CalculateNextState_incorrectIndex_throwException()
        {
            var size = 5;
            var incorrectIndex = 100;
            var sut = new Grid(new GridSize(size, size));

            Action act = () => sut.GetNeighbourList(incorrectIndex, incorrectIndex);

            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
