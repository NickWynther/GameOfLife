using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLife
{
    /// <summary>
    /// Game menu to interact with user
    /// </summary>
    public class Menu
    {
        private GameRepository _gameRepo;
        private GameManager _gameManager;
        private IPlayerInterface _playerInterface;
        private ISaveManager _saveManager;

        /// <summary>
        /// Create menu.
        /// </summary>
        /// <param name="rules">'Game of life' rules implementation</param>
        public Menu(IRules rules, IPlayerInterface playerInterface, ISaveManager saveManager)
        {
            _playerInterface = playerInterface;
            _saveManager = saveManager;
            _gameRepo = new GameRepository();
            _gameManager = new GameManager( playerInterface, _gameRepo , rules);
        }

        /// <summary>
        /// Start waiting for player commands and execute them in a loop
        /// </summary>
        public void Run()
        {
            _playerInterface.ShowMenu();
            while (true)
            {
                try
                {
                    var command = _playerInterface.GetCommand();
                    ExecuteCommand(command);
                }
                catch(Exception ex)
                {
                    _playerInterface.ShowException(ex);
                    Pause();
                }
            }
        }

        /// <summary>
        /// Execute player command.
        /// </summary>
        public void ExecuteCommand(MenuCommand command)
        {
            if (command == MenuCommand.PauseExecution)
            {
                Pause();
                return;
            }

            if (command == MenuCommand.PauseExecution)
            {
                Resume();
                return;
            }
            //pause games -> execute command -> resume games.
            Pause();
            switch (command)
            {
                case MenuCommand.NewGame: 
                    StartNewGame(); 
                    break;
                case MenuCommand.LoadGame: 
                    LoadGame(); 
                    break;
                case MenuCommand.SaveGame: 
                    SaveGame(); 
                    break;
                case MenuCommand.Exit: 
                    Exit();  
                    break;
                case MenuCommand.AddToScreen:
                    AddToScreen();
                    break;
                case MenuCommand.ThousandNewGames:
                    RunThousand();
                    break;
                case MenuCommand.AddEightToScreen:
                    ShowEight();
                    break;
                case MenuCommand.HideFromScreen:
                    HideFromScreen();
                    break;
                case MenuCommand.LoadAllGames:
                    LoadAllGames();
                    break;
                case MenuCommand.SaveAllGames:
                    SaveAllGames();
                    break;
            }
            Resume();
        }

        /// <summary>
        /// Exit application.
        /// </summary>
        private void Exit() => Environment.Exit(0);

        /// <summary>
        /// Pause all running games.
        /// </summary>
        private void Pause() => _gameManager.Pause();

        /// <summary>
        /// Resume games execution.
        /// </summary>
        private void Resume() => _gameManager.Resume();

        /// <summary>
        /// Select 8 running games and show them on the screen. 
        /// Others game will be removed from screen.
        /// </summary>
        private void ShowEight() => _gameManager.SetToScreen(_playerInterface.SelectGame(8));

        /// <summary>
        /// Select game and hide it from screen.
        /// </summary>
        private void HideFromScreen() => _gameManager.HideFromScreen(_playerInterface.SelectGame());

        /// <summary>
        /// Select game and add it to the screen.
        /// </summary>
        private void AddToScreen() => _gameManager.SetToScreen(_playerInterface.SelectGame());

        /// <summary>
        /// Select game and save it to storage.
        /// </summary>
        private void SaveGame() => _saveManager.Save(_gameRepo.Get(_playerInterface.SelectGame()));

        /// <summary>
        /// Load game from storage and add it to running games. 
        /// If no other games running, show this game on the screen.
        /// </summary>
        private void LoadGame()
        {
            var game = _saveManager.Load();
            _gameRepo.Add(game);
            _gameManager.ShowDefault();
        }

        /// <summary>
        /// Save all running games from repository to storage.
        /// </summary>
        private void SaveAllGames() => _saveManager.SaveAll(_gameRepo);

        /// <summary>
        /// Load all saved games from storage to repository and start execute them.
        /// </summary>
        private void LoadAllGames()
        {
            var games = _saveManager.LoadAll();
            _gameRepo.Add(games);
            _gameManager.ShowDefault();
        }

        /// <summary>
        /// Ask player for grid size and start new game.
        /// </summary>
        private void StartNewGame()
        {
            _playerInterface.GetGridSize(out uint rows, out uint column);
            _gameManager.StartNewGame(rows, column);
        }

        /// <summary>
        /// Ask player for grid size and start 1000 new games.
        /// </summary>
        private void RunThousand()
        {
            _playerInterface.GetGridSize(out uint rows, out uint column);
            _gameManager.StartNewGame(rows, column, 1000);
        }
    }
}
