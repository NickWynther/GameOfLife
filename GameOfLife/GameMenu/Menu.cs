using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GameOfLife.GameMenu;

namespace GameOfLife
{
    public class Menu
    {
        public GameOfLife Game { get; set; }
        public bool PlayPauseGame { get; set; }
        public bool ContinueGame { get; set; }


        public IGameView GameView { get; set; }
        public ISizeReader SizeReader { get; set; }
        public ICommandReader CommandReader { get; set; }


        public Menu(IGameView gameView , ISizeReader sizeReader , ICommandReader commandReader)
        {
            GameView = gameView;
            SizeReader = sizeReader;
            CommandReader = commandReader;
        }

        public void Start()
        {
            GameView.ShowMenu();

            while (true)
            {
                
                var command = CommandReader.GetCommandFromPlayer();
                Choose(command);
            }
        }



        public async Task NewRound()
        {
            PlayPauseGame = true;
            ContinueGame = true;
            while (ContinueGame) 
            {
                while (PlayPauseGame && ContinueGame)
                {
                    Game.NextIteration();
                    GameView.ShowMenu();
                    await Task.Delay(1000); //Calculate the next generation after 1 second
                } 
            }
        }

      

        public void Choose(MenuChoice command)
        {
            switch (command)
            {
                case MenuChoice.New: { StartNewGame(GameView);} break;
                case MenuChoice.Load:{ LoadGame();} break;
                case MenuChoice.PauseResume: {PauseResumeGame(); } break;
                case MenuChoice.Save: { SaveGame(); } break;
                case MenuChoice.Exit: { ExitGame(); } break;
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

        public async void StartNewGame(IGameView gameView)
        {
            TerminateCurrentRound();
            SizeReader.GetSize(out uint rows, out uint column);
            Game = new GameOfLife(rows, column, gameView);
            //run
            await NewRound();
        }

        public async void LoadGame()
        {
            ///TODO:check file
            ///TODO:terminate running game if it exist
            ///

            TerminateCurrentRound();

            Game = SaveRestoreGame.RestoreDataFromFile();
            Game.OuputView = GameView;
            await NewRound();
        }

        private void TerminateCurrentRound()
        {
            ContinueGame = false;
            PlayPauseGame = false;
            Thread.Sleep(1000);
        }

        public void SaveGame()
        {
            SaveRestoreGame.SaveDataToFile(Game);
        }




    }
}
