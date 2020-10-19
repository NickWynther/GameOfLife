using Autofac.Extras.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameOfLife.Tests
{
    public class Menu_LoadGame
    {
        [Fact]
        public void LoadGame_command_Works()
        {
            //arrange
            using var mock = AutoMock.GetLoose();
            mock.Mock<IRules>();

            var game = new GameOfLife(new GridSize(5, 5));
            mock.Mock<ISaveManager>()
                .Setup(sm => sm.Load())
                .Returns(game);

            mock.Mock<IPlayerInterface>()
                .Setup(p => p.GetCommand())
                .Returns(MenuCommand.LoadGame);

            var sut = mock.Create<Menu>();

            //act
            sut.Run();

            //assert
            mock.Mock<IPlayerInterface>().Verify(p => p.GetCommand(), Times.Once);
            mock.Mock<ISaveManager>().Verify(sm => sm.Load(), Times.Once);
        }
    }
}
