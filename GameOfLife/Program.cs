using GameOfLife;

//setup game menu
var menu = new Menu(
    new ClassicRules(),
    new ConsoleUI(),
    new GameJsonSave());
//start menu 
menu.Run();
