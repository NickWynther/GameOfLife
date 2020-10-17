using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    /// <summary>
    /// Console implementation of user interface.
    /// </summary>
    class ConsoleUI : IPlayerInterface
    {
        private IGameSelector _gameSelector;
        private IGameView _gameView;
        private ICommandReader _commandReader;
        private ISizeReader _sizeReader;


        /// <summary>
        /// Create console user interface.
        /// </summary>
        public ConsoleUI()
        {
            _gameSelector = new ConsoleGameSelector();
            _gameView = new ConsoleView();
            _commandReader = new ConsoleCommandReader();
            _sizeReader = new ConsoleSizeReader();
        }

        /// <summary>
        /// Clear game screen.
        /// </summary>
        public void ClearScreen() =>_gameView.ClearScreen();

        /// <summary>
        /// Get command chosen by player.
        /// </summary>
        /// <returns>Enum instance associated with chosen comand</returns>
        public MenuCommand GetCommand() =>  _commandReader.GetCommand();

        /// <summary>
        /// Get grid size from player for new game instance creating.
        /// </summary>
        public GridSize GetGridSize() => _sizeReader.GetGridSize();
        
        /// <summary>
        /// Player selects game id.
        /// </summary>
        /// <returns>Game id</returns>
        public int SelectGame() => _gameSelector.SelectGame();

        /// <summary>
        /// Player selects many game ids.
        /// </summary>
        /// <param name="count">number of games</param>
        /// <returns>list of selected games id</returns>
        public List<int> SelectGame(int count) => _gameSelector.SelectGame(count);

        /// <summary>
        /// Show exception message occured during a game process.
        /// </summary>
        /// <param name="ex"></param>
        public void ShowException(Exception ex) => _gameView.ShowException(ex);

        /// <summary>
        /// Show particular game grid.
        /// </summary>
        public void ShowGrid(GameOfLife game) => _gameView.ShowGrid(game);

        /// <summary>
        /// Show menu with command list.
        /// </summary>
        public void ShowMenu() => _gameView.ShowMenu();

        /// <summary>
        /// Show statistic for all running games.
        /// </summary>
        public void ShowStatistic(int gameCount, int totalCells) => _gameView.ShowStatistic(gameCount, totalCells);
    }
}
