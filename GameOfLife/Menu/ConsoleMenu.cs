using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Menu;

namespace GameOfLife
{
    public class ConsoleMenu
    {
        public GameOfLife game { get; set; }
        public bool RunSimulation { get; set; }

        public async Task Run()
        {
            RunSimulation = true;
            while (true) 
            {
                while (RunSimulation)
                {
                    game.NextIteration();
                    
                    Show(); //show menu
                    await Task.Delay(1000); //Calculate the next generation after 1 second
                } 
            }
        }

        public void Show()
        {
            string menuCommands = "[N].New [L].Load [S].Save [P].Pause/Play [E].Exit ";
            Console.WriteLine(menuCommands);
        }

        public MenuChoice GetCommand()
        {
            var comandKey = Console.ReadKey();

            switch (comandKey.Key)
            {
                case ConsoleKey.N : return MenuChoice.New;
                case ConsoleKey.L : return MenuChoice.Load;
                case ConsoleKey.P : return MenuChoice.PausePlay;
                case ConsoleKey.S : return MenuChoice.Save;
                case ConsoleKey.E : return MenuChoice.Exit;
            }
            return MenuChoice.Empty;
        }

        public void Choose(MenuChoice command)
        {
            switch (command)
            {
                case MenuChoice.New:
                    {
                        StartNewGame();
                    }
                    break;
                case MenuChoice.Load:
                    {
                        LoadGame();
                    }
                    break;
                case MenuChoice.PausePlay:
                    {
                        RunSimulation = !RunSimulation;
                    }
                    break;
                case MenuChoice.Save:
                    {
                        SaveGame();
                    }
                    break;
                case MenuChoice.Exit:
                    {
                        
                    }
                    break;
            }
        }

        public async void StartNewGame()
        {
            //inuput size
            game = new GameOfLife(15, 30, new ConsoleView());
            //run
            await Run();
        }

        public async void LoadGame()
        {
         
            //check file
            //stop existing game if its run

            game = SaveRestoreGame.RestoreDataFromFile();
            await Run();
        }

        public void SaveGame()
        {
            SaveRestoreGame.SaveDataToFile(game);
        }




    }
}
