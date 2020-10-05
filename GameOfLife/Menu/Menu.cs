using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Menu
    {
        public GameOfLife Game { get; set; }
        public bool PlayPauseGame { get; set; }

        private CancellationTokenSource _tokenSource;

        public IGameView GameView { get; set; }
        public ISizeReader SizeReader { get; set; }
        public ICommandReader CommandReader { get; set; }
        public ISaveManager SaveManager { get; set; }
        public Menu(IGameView gameView, ISizeReader sizeReader,
            ICommandReader commandReader, ISaveManager saveManager)
        {
            GameView = gameView;
            SizeReader = sizeReader;
            CommandReader = commandReader;
            SaveManager = saveManager;
        }

        public void Start()
        {
            GameView.ShowMenu();
            while (true)
            {
                var command = CommandReader.GetCommandFromPlayer();
                ExecuteCommand(command);
            }
        }

        public async void RunNewRound()
        {
            _tokenSource = new CancellationTokenSource();
            var token = _tokenSource.Token;
            await (Task.Factory.StartNew(async () =>
            {
                PlayPauseGame = true;
                while (true)
                {
                    while (PlayPauseGame)
                    {
                        if (token.IsCancellationRequested)
                        {
                            return;
                        }

                        Game.NextIteration();
                        GameView.ShowMenu();
                        await Task.Delay(1000); //Calculate the next generation after 1 second
                    }
                }
            }, token));
        }      

        public void ExecuteCommand(MenuCommand command)
        {
            switch (command)
            {
                case MenuCommand.New: 
                    StartNewGame(); 
                    break;
                case MenuCommand.Load: 
                    LoadGame(); 
                    break;
                case MenuCommand.PauseResume: 
                    PauseResumeGame();
                    break;
                case MenuCommand.Save: 
                    SaveGame(); 
                    break;
                case MenuCommand.Exit: 
                    ExitGame();  break;
            }
        }

        private static void ExitGame()
        {
            Environment.Exit(0);
        }

        private void PauseResumeGame()
        {
            PlayPauseGame = !PlayPauseGame;
        }

        public void StartNewGame()
        {
            TerminateCurrentRound();
            SizeReader.GetSize(out uint rows, out uint column);
            Game = new GameOfLife(rows, column, GameView);
            RunNewRound();
        }

        public void LoadGame()
        {
            //terminate running game round if it exist
            TerminateCurrentRound();

            ///TODO:check file
            Game = SaveManager.Load();
            Game.OuputView = GameView;
            RunNewRound();
        }

        private void TerminateCurrentRound()
        {
            if (_tokenSource != null)
            {
                _tokenSource.Cancel();
            }
        }

        public void SaveGame()
        {
            SaveManager.Save(Game);
        }
    }
}
