using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameOfLife.Tests
{
    public class GameRepository_Remove
    {
        [Fact]
        public void Remove_correctId_works()
        {
            var gridSize = new GridSize(5, 5);
            var game = new GameOfLife(gridSize);
            var sut = new GameRepository {game};
            var repoSizeBeforeRemove = sut.Count();
            var idToRemove = game.Id;

            sut.Remove(idToRemove);

            var repoSizeAfterRemove = sut.Count();
            repoSizeAfterRemove.Should().Be(repoSizeBeforeRemove - 1);
        } 

        [Fact]
        public void Remove_incorrectId_ThrowException()
        {
            var sut = new GameRepository();
            var incorrectId = 1;

            Action act = () => sut.Remove(incorrectId);

            act.Should().Throw<ArgumentException>().WithMessage("Incorrect game id.");
        } 
    }
}
