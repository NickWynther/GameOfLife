using Autofac.Extras.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameOfLife.Tests
{
    public class GameManager_SetToScreen
    {
        [Fact]
        public void SetToScreen_GameFromRepository_Works()
        {
            //arrange
            using var mock = AutoMock.GetLoose();
            mock.Mock<IGameView>();
            var game = new GameOfLife(new GridSize(5, 5));
            var id = game.Id;

            mock.Mock<IGameRepository>()
                .Setup(gr=>gr.Get(id))
                .Returns(game);

            var sut = mock.Create<GameManager>();

            //act
            sut.SetToScreen(id);

            //assert
            mock.Mock<IGameRepository>()
                .Verify(gr => gr.Get(id), Times.Once);
        }
    }
}
