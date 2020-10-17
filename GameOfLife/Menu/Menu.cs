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
        private IGameRepository _gameRepo;
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
            _gameManager = new (playerInterface, _gameRepo , rules);
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
        /// Get action for command.
        /// </summary>
        /// <param name="command">Command enum</param>
        /// <returns>Action with method to invoke</returns>
        private Action GetCommandAction(MenuCommand command)
        {
            return command switch
            {
                MenuCommand.NewGame => new (StartNewGame),
                MenuCommand.LoadGame => new (LoadGame),
                MenuCommand.SaveGame => new (SaveGame),
                MenuCommand.Exit => new (Exit),
                MenuCommand.AddToScreen => new (AddToScreen),
                MenuCommand.ThousandNewGames => new (RunThousand),
                MenuCommand.AddEightToScreen => new (ShowEight),
                MenuCommand.HideFromScreen => new (HideFromScreen),
                MenuCommand.LoadAllGames => new (LoadAllGames),
                MenuCommand.SaveAllGames => new (SaveAllGames),
                MenuCommand.PauseExecution => new (Pause),
                MenuCommand.ResumeExecution => new (Resume),
            };
        }

        /// <summary>
        /// Execute player command.
        /// Workflow:
        /// pause games -> execute command -> resume games -> 
        ///  if no games games on screen, show first game from repository.
        /// </summary>
        private void ExecuteCommand(MenuCommand command)
        {
            if (command == MenuCommand.PauseExecution)
            {
                Pause();
                return;
            }

            if (command == MenuCommand.ResumeExecution)
            {
                Resume();
                return;
            }

            Pause();
            GetCommandAction(command).Invoke();
            Resume();
            _gameManager.ShowDefault();
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
        /// </summary>
        private void LoadGame() => _gameRepo.Add(_saveManager.Load());
        
        /// <summary>
        /// Save all running games from repository to storage.
        /// </summary>
        private void SaveAllGames() => _saveManager.SaveAll(_gameRepo);

        /// <summary>
        /// Load all saved games from storage to repository and start execute them.
        /// </summary>
        private void LoadAllGames() => _gameRepo.Add(_saveManager.LoadAll());
        
        /// <summary>
        /// Ask player for grid size and start new game.
        /// </summary>
        private void StartNewGame() => _gameManager.StartNewGame(_playerInterface.GetGridSize());
        
        /// <summary>
        /// Ask player for grid size and start 1000 new games.
        /// </summary>
        private void RunThousand() => _gameManager.StartNewGame(_playerInterface.GetGridSize());
        
    }
}
