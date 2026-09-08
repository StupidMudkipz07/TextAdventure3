Player player = new() { Hp = 100, Damage = 67, Defense = 1 };

player.SetName();

Console.WriteLine("hej " + player.Name);
Console.WriteLine("Idag ska du utforska Adolf kirk köping!");
Console.ReadLine();

AdolfKirkKöpingResidents anton = new() { Hp = 100, Damage = 3, Name = "anton", Defense = 1 };
Item kirkItem = new Item() { Name = "Oskar Sia", Description =  "Köttingaste saken på denna sidan floden" };
anton.inventory.Add(kirkItem);
Fight köttig = new Fight(player, anton);



LocationManager locationManager = new(player,new(),"Torget");

köttig.ExecuteFight();
locationManager.PlayRealGAMEOMMG();

Console.ReadLine();
