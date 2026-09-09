struct Location
{
    [JsonInclude] public string Name = "";
    [JsonInclude] public List<string> Descriptions = new();
    [JsonInclude] public List<string> PossibleNextLocations = new();
    [JsonInclude] public List<string> Enemies = new();
    public bool NeedItemToEnter = false;
    [JsonInclude] public string KeyItem = "";

    public void PrintLocation()
    {
        Console.WriteLine(Name);

        Console.WriteLine(S.ListToString(Descriptions));

        Console.WriteLine(S.ListToString(PossibleNextLocations));

        if (Enemies.Count >= 0)
        {
            Console.WriteLine(S.ListToString(Enemies));
        }
    }

    public Location()
    {
        //PrintLocation();
    }
}