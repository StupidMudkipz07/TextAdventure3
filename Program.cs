global using System.Text.Json.Serialization;

Player player = new() { Hp = 100, Damage = 67, Defense = 1, StealChance = 67 };

Console.Clear();

ItemManager itemManager = new();

itemManager.InitializeItems();

FightManager fightManager = new();

fightManager.InitializeEnemies();

LocationManager locationManager = new(player, fightManager, "Torget");

locationManager.PlayRealGAMEOMMG();

Console.ReadLine();
