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

        
    }

    public void PlayRealGAMEOMMG()
    {
        while(true) PlayLocation(currentLocation);
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