using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Menu
    {
        public GameRound GameRound { get; set; }
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
                    ExitGame();  
                    break;
            }
        }

        private static void ExitGame()
        {
            Environment.Exit(0);
        }

        private void PauseResumeGame()
        {
            GameRound.PauseResume();
        }

        public void StartNewGame()
        {
            GameRound?.Terminate();
            SizeReader.GetSize(out uint rows, out uint column);
            GameRound = new GameRound(rows, column, GameView);
        }

        public void LoadGame()
        {
            //terminate running game round if it exist
            GameRound?.Terminate();

            ///TODO:check file
            GameOfLife Game = SaveManager.Load();
            GameRound = new GameRound(Game,GameView);
        }

        public void SaveGame()
        {
            SaveManager.Save(GameRound.Game);
        }
    }
}
