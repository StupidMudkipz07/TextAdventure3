global using System.Text.Json.Serialization;
// Enables debugging 
S.debug = false;
// Sets the player in the testing enviroment
// This let the player try all features of the game
S.Testing = false;

S.StartGameDialogue();

Player player = new();
ItemManager itemManager = new();
FightManager fightManager = new(itemManager);
LocationManager locationManager = new(player, fightManager, "Bussen");

//player.AddItem("passerkort", itemManager);
    
locationManager.PlayRealGAMEOMMG();

//www.instagram.com/popular/adolf-kirk/

Console.ReadLine();
