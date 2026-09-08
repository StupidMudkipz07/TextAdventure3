global using System.Text.Json.Serialization;

Console.Clear();

ItemManager itemManager = new();

FightManager fightManager = new(itemManager);

//världens mest läsbara kod här!!!!!!
LocationManager locationManager = new(new() { Hp = 100, Damage = 67, Defense = 1, StealChance = 67 },
fightManager, 
 "Torget");

locationManager.PlayRealGAMEOMMG();

Console.ReadLine();
