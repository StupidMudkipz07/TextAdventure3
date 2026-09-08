Player player = new() { Hp = 100, Damage = 67 };

player.SetName();

Console.WriteLine("hej " + player.Name);
Console.WriteLine("Idag ska du utforska Adolf kirk köping!");
Console.ReadLine();

LocationManager locationManager = new(player,"Torget");

locationManager.PlayRealGAMEOMMG();

Console.ReadLine();
