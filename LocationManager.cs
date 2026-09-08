class LocationManager
{
    public Dictionary<string, Location> locationsOfAdolfKirkKöping = new();

    public string resourceFilePath = "locations.json";

    Location currentLocation;
    Player player;

    FightManager fightManager;

    void PlayLocation(Location location)
    {
        Console.Clear();
        foreach (string text in location.Descriptions)
        {
            System.Console.WriteLine(text);
            //ändra till readkey kanske om konsolen tillåter det
            Console.ReadKey();
        }

        //köttigaste fighten pågår här
        if (location.Enemies.Count > 0)
        {
            Random randomEnemyIndex = new Random();

            string enemyToFight = location.Enemies[randomEnemyIndex.Next(0, location.Enemies.Count)];

            AdolfKirkKöpingResidents enemy = fightManager.allEnemies[enemyToFight];

            fightManager.StartNewFight(player, enemy);
        }

        System.Console.WriteLine("välj vart du vill gå");
        System.Console.WriteLine(S.ListToString(location.PossibleNextLocations));

        //längsta kodraden!!!!!!!11
        currentLocation = locationsOfAdolfKirkKöping[location.PossibleNextLocations[S.GetIntFromConsole(1, location.PossibleNextLocations.Count) - 1]];
        //den basically tar int från konsolen och sedan plockar det indexet från string listan och tar den locationen som matchar
    }

    public void PlayRealGAMEOMMG()
    {
        while (true) PlayLocation(currentLocation);
    }

    // load locations to a list
    List<Location> LoadLocations(string filePath)
    {
        string data = File.ReadAllText(filePath);

        return JsonSerializer.Deserialize<List<Location>>(data, new JsonSerializerOptions { IncludeFields = true }) ?? [];
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