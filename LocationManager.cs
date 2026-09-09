class LocationManager
{
    public static Dictionary<string, Location> locationsOfAdolfKirkKöping = new();

    public string resourceFilePath = "locations.json";

    Location currentLocation;
    Player player;

    FightManager fightManager;

    void ReadLocationText(Location location)
    {
        foreach (string text in location.Descriptions)
        {
            System.Console.WriteLine(text);
            //ändra till readkey kanske om konsolen tillåter det
            Console.ReadKey();
        }
    }

    void PLayFight(Player player, FightManager fightManager, Location location)
    {
        Random randomEnemyIndex = new Random();

        int kirkigasteMikael = randomEnemyIndex.Next(0, location.Enemies.Count);

        string enemyToFight = location.Enemies[kirkigasteMikael]; //välj en random string från listan

        location.Enemies.Remove(enemyToFight); // tar bort stringen som valdes från listan

        AdolfKirkKöpingResidents enemy = fightManager.allEnemies[enemyToFight]; //hitta fienden som associearas med stringen

        fightManager.StartNewFight(player, enemy); //starta fight med denna fiende
    }

    void PlayLocation(Location location)
    {
		Console.WriteLine(); // Console.Clear() Removed cuz you cant see item requierment text.

        //läs upp all text för stället
        ReadLocationText(location);

        //köttigaste fighten pågår här
        if (location.Enemies.Count > 0)
        {
            PLayFight(player, fightManager, location);
        }

        System.Console.WriteLine("välj vart du vill gå");
        System.Console.WriteLine(S.ListToString(location.PossibleNextLocations));

        //längsta kodraden!!!!!!!11
        var futureLocation = locationsOfAdolfKirkKöping[location.PossibleNextLocations[S.GetIntFromConsole(1, location.PossibleNextLocations.Count) - 1]];
        //den basically tar int från konsolen och sedan plockar det indexet från string listan och tar den locationen som matchar

        //här kommer bästa koden!!! ;)
        if (futureLocation.NeedItemToEnter)
        {
            bool success = false;
            string itemSomKrävs = futureLocation.KeyItem;
			Console.WriteLine($"Du behöver {itemSomKrävs} för att ta sig in hit");

            //Item temp;

            if (player.inventory.Count() > 0)
            {
                var temp = player.inventory.Where(c => c.Name == itemSomKrävs).First();

                if (temp.Name == itemSomKrävs)
                {
                    Console.WriteLine($"Du har en {itemSomKrävs}!");
                    currentLocation = futureLocation;
                    success = true;
                }
            }
            
            if (!success)
            {
                Console.WriteLine($"Du har inte {itemSomKrävs} och can inte gå till {futureLocation.Name}");
            }
        }
        else
        {
            currentLocation = futureLocation;
		}
    }

    public void PlayRealGAMEOMMG()
    {
        while (true) PlayLocation(currentLocation);
    }

    // load locations to a list
    List<Location> LoadLocations(string filePath)
    {
        string data = File.ReadAllText(filePath);

        var loadedLocations = JsonSerializer.Deserialize<List<Location>>(data, new JsonSerializerOptions { IncludeFields = true }) ?? [];

        for (var i = 0; i < loadedLocations.Count(); ++i)
        {
            var theLocation = loadedLocations[i];
            theLocation.NeedItemToEnter = !string.IsNullOrEmpty(theLocation.KeyItem);
            loadedLocations[i] = theLocation;
        }

        return loadedLocations;
    }

    //loads all the locations to the dictionary
    void InitializeLocations()
    {
        foreach (Location location in LoadLocations(resourceFilePath))
        {
            locationsOfAdolfKirkKöping.Add(location.Name, location);

            //debug bullshit
            //location.PrintLocation();
        }
    }

    public LocationManager(Player player, FightManager fightManager, string startLocation)
    {
        InitializeLocations();
        this.player = player;
        this.fightManager = fightManager;
        currentLocation = locationsOfAdolfKirkKöping[startLocation];
    }
}