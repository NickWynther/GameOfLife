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
            string menuCommands = "1.New 2.Load 3.Save 4.Pause/Play 5.Exit ";
            Console.WriteLine(menuCommands);
        }

        public MenuChoice GetCommand()
        {
            string command = Console.ReadLine();
            return (MenuChoice)Enum.Parse(typeof(MenuChoice), command);
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
            game = SaveRestoreGame.RestoreDataFromFile();
            await Run();
        }

        public void SaveGame()
        {
            SaveRestoreGame.SaveDataToFile(game);
        }




    }
}
