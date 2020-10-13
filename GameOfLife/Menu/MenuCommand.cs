using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    /// <summary>
    /// Represents palyer commands.
    /// </summary>
    public enum MenuCommand
    {
        /// <summary>
        /// Start new game.
        /// </summary>
        NewGame,

        /// <summary>
        /// Start 1000 new games (in parallel)
        /// </summary>
        ThousandNewGames,

        /// <summary>
        /// Load one game from storage.
        /// </summary>
        LoadGame,

        /// <summary>
        /// Save one game to storage.
        /// </summary>
        SaveGame,

        /// <summary>
        /// Load all games from storage.
        /// </summary>
        LoadAllGames,

        /// <summary>
        /// Save all games to storage.
        /// </summary>
        SaveAllGames,

        /// <summary>
        /// Pause execution of running games
        /// </summary>
        PauseExecution,

        /// <summary>
        /// Resume execution of paused games.
        /// </summary>
        ResumeExecution,

        /// <summary>
        /// Add games with selected id to screen.
        /// </summary>
        AddToScreen,

        
        /// <summary>
        /// Select 8 games and add them to screen. Other games on screen will be removed.
        /// </summary>
        AddEightToScreen,

        /// <summary>
        /// Hide game with selected id from screen.
        /// </summary>
        HideFromScreen,

        /// <summary>
        /// Exit application.
        /// </summary>
        Exit,

        /// <summary>
        /// No commands selected.
        /// </summary>
        Empty
    }
}
