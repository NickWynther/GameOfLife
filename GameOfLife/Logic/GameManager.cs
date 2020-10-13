using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GameOfLife
{
    /// <summary>
    /// Functionality to manipulate with games.
    /// </summary>
    public class GameManager
    {
        private IGameView _gameView;
        private GameRepository _gameRepo;
        private GameRepository _gamesOnScreen;
        private Timer _timer;
        private IRules _rules;

        /// <summary>
        /// Basic constructor.
        /// </summary>
        /// <param name="gameView">Game window handler.</param>
        /// <param name="gameRepo">Repository with games.</param>
        /// <param name="rules">'Game of life' rules implementation</param>
        public GameManager(IGameView gameView, GameRepository gameRepo, IRules rules)
        {
            _gameView = gameView;
            _gameRepo = gameRepo;
            _rules = rules;
            _gamesOnScreen = new GameRepository();
            SetupTimer();
        }

        /// <summary>
        /// Setup timer object to execute games iterations every constat period of time.
        /// </summary>
        private void SetupTimer()
        {
            TimerCallback tm = new TimerCallback(NextIteration);
            _timer = new Timer(tm, null, Timeout.Infinite, Timeout.Infinite);
        }

        /// <summary>
        /// Pause all game execution.
        /// </summary>
        public void Pause() => _timer?.Change(Timeout.Infinite, Timeout.Infinite);

        /// <summary>
        /// Resume all game execution.
        /// </summary>
        public void Resume() => _timer?.Change(0, 1000);

        /// <summary>
        /// Hide game from screen.
        /// </summary>
        /// <param name="id">Game id</param>
        public void HideFromScreen(int id) => _gamesOnScreen.Remove(id);

        /// <summary>
        /// Add game to screen.
        /// </summary>
        /// <param name="id">Game id</param>
        public void SetToScreen(int id) => _gamesOnScreen.Add(_gameRepo.Get(id));

        /// <summary>
        /// Set games from list to screen and remove others.
        /// </summary>
        /// <param name="idList">List of games id</param>
        public void SetToScreen(List<int> idList)
        {
            _gamesOnScreen.Clear();
            idList.ForEach(id => SetToScreen(id));
        }

        /// <summary>
        /// Create new game and add it to repository.
        /// This games will be started executing immediately
        /// </summary>
        public void StartNewGame(uint rowCount , uint columnCount)
        {
            _gameRepo.Add(new GameOfLife(rowCount, columnCount));
            ShowDefault();
        }

        /// <summary>
        /// Create new games and add them to repository.
        /// This games will be started executing immediately.
        /// </summary>
        /// <param name="count">Count of new games.</param>
        public void StartNewGame(uint rowCount, uint columnCount , int count)
        {
            for (int i = 0; i < count; i++)
            {
                _gameRepo.Add(new GameOfLife(rowCount, columnCount));
            }

            ShowDefault();
        } 

        /// <summary>
        /// If screen is empty but there are running games on the background. Show first game on screen.
        /// </summary>
        public void ShowDefault()
        {
            if (_gamesOnScreen.Count() == 0 && _gameRepo.Count() > 0)
            {
                _gamesOnScreen.Add(_gameRepo.Get(1));
            }
        }

        /// <summary>
        /// This method is called by timer in the loop every constatnt period of time.
        /// Method represent game basic iteration:
        /// Update views for games on screen.
        /// Calculate next generations for all games.
        /// </summary>
        /// <param name="obj">This parameter is requierd by delegat signature for passing this method to Timer. Can set it to null </param>
        public void NextIteration(object obj)
        {
            ShowToPlayer();
            _gameRepo.ToList().ForEach(game => game.NextIteration(_rules));
        }

        /// <summary>
        /// Show next generation for games on screen.
        /// Update statistic.
        /// </summary>
        private void ShowToPlayer()
        {
            _gameView.ClearScreen();
            _gamesOnScreen.ToList().ForEach(game => _gameView.ShowGrid(game));
            _gameView.ShowStatistic(_gameRepo.Count(), _gameRepo.TotalAliveCells());
            _gameView.ShowMenu();
        }
    }
}
