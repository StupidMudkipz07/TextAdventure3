global using System.Text.Json.Serialization;

Console.Clear();

//världens mest läsbara kod här!!!!!!
LocationManager locationManager = new(new() { Hp = 100, Damage = 67, Defense = 1, StealChance = 67 }, new(new()), "Torget");

locationManager.PlayRealGAMEOMMG();

Console.ReadLine();
