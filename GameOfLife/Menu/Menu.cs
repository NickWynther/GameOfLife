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
        public IGameView GameView { get; set; }
        public ISizeReader SizeReader { get; set; }
        public ICommandReader CommandReader { get; set; }
        public IGameSelector GameSelector { get; set; }
        public ISaveManager SaveManager { get; set; }
        public Menu(IGameView gameView, ISizeReader sizeReader,
            ICommandReader commandReader, IGameSelector gameSelector, ISaveManager saveManager)
        {
            GameView = gameView;
            SizeReader = sizeReader;
            CommandReader = commandReader;
            GameSelector = gameSelector;
            SaveManager = saveManager;

            _gameRepo = new GameRepository();
            _gameManager = new GameManager(GameView, _gameRepo);
        }

        /// <summary>
        /// Start waiting for player commands and execute them in a loop
        /// </summary>
        public void Run()
        {
            GameView.ShowMenu();
            while (true)
            {
                try
                {
                    var command = CommandReader.GetCommandFromPlayer();
                    ExecuteCommand(command);
                }
                catch(Exception ex)
                {
                    GameView.ShowException(ex);
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
                case MenuCommand.LoadFromFile: 
                    LoadGame(); 
                    break;
                case MenuCommand.SaveToFile: 
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
        private void ShowEight() => _gameManager.SetGamesToShow(GameSelector.SelectGame(8));

        /// <summary>
        /// Select game and hide it from screen.
        /// </summary>
        private void HideFromScreen() => _gameManager.Hide(GameSelector.SelectGame());

        /// <summary>
        /// Select game and add it to the screen.
        /// </summary>
        private void AddToScreen() => _gameManager.AddToShowList(GameSelector.SelectGame());

        /// <summary>
        /// Select game and save it to storage.
        /// </summary>
        private void SaveGame() => SaveManager.Save(_gameRepo.Get(GameSelector.SelectGame()));

        /// <summary>
        /// Load game from storage and add it to running games. 
        /// If no other games running, show this game on the screen.
        /// </summary>
        public void LoadGame()
        {
            var game = SaveManager.Load();
            _gameRepo.Add(game);
            _gameManager.ShowDefault();
        }

        /// <summary>
        /// Ask player for grid size and start new game.
        /// </summary>
        private void StartNewGame()
        {
            SizeReader.GetSize(out uint rows, out uint column);
            _gameManager.StartNewGame(rows, column);
        }

        /// <summary>
        /// Ask player for grid size and start 1000 new games.
        /// </summary>
        private void RunThousand()
        {
            SizeReader.GetSize(out uint rows, out uint column);
            _gameManager.StartNewGame(rows, column, 1000);
        }
    }
}
