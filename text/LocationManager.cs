class LocationManager
{
    public Dictionary<string, Location> locationsOfAdolfKirkKöping = new();

    Location currentLocation;
    Player player;

    void PlayLocation(Location location)
    {
        foreach (string text in location.Descriptions)
        {
            System.Console.WriteLine(text);
            Console.ReadLine();
        }

        //hända figth

        System.Console.WriteLine("välj vart du vill gå");
        System.Console.WriteLine(S.ListToString(location.PossibleNextLocations));

        int svar = S.GetIntFromConsole(1, location.PossibleNextLocations.Count + 1);

        Location nextLocation = locationsOfAdolfKirkKöping[location.PossibleNextLocations[svar - 1]];
        currentLocation = nextLocation;
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
        foreach (Location location in LoadLocations("locations.json"))
        {
            locationsOfAdolfKirkKöping.Add(location.Name, location);

            //debug bullshit
            //location.PrintLocation();
        }
    }

    public LocationManager(Player player, string startLocation)
    {
        InitializeLocations();
        this.player = player;
        currentLocation = locationsOfAdolfKirkKöping[startLocation];
    }
}