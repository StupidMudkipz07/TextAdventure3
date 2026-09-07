Player player = new() { Hp = 100, attack = 67 };

player.SetName();

Console.WriteLine("hej " + player.name);
Console.WriteLine("Idag ska du utforska Adolf kirk köping!");
Console.ReadLine();

LocationManager locationManager = new(player,"Torget");

locationManager.PlayRealGAMEOMMG();

Console.ReadLine();
