using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class GameRound
    {
        public IGameView GameView { get; set; }
        public GameOfLife Game { get; set; }
        public bool PlayPauseRound { get; set; }

        private CancellationTokenSource _tokenSource;

        public GameRound(GameOfLife game , IGameView gameView)
        {
            Game = game;
            game.OuputView = gameView;
            GameView = gameView;
            Run();
        }

        public GameRound(uint rows , uint columns , IGameView gameView)
        {
            GameView = gameView;
            Game = new GameOfLife(rows, columns, gameView);
            Run();
        }

        public async void Run()
        {
            _tokenSource = new CancellationTokenSource();
            var token = _tokenSource.Token;
            await (Task.Factory.StartNew(async () =>
            {
                PlayPauseRound = true;
                while (true)
                {
                    while (PlayPauseRound)
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

        public void PauseResume()
        {
            PlayPauseRound = !PlayPauseRound;
        }

        public void Terminate()
        {
            _tokenSource?.Cancel();   
        }
    }
}
