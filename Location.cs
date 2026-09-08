struct Location
{
    public string Name = "";
    public List<string> Descriptions = new();
    public List<string> PossibleNextLocations = new();
    public List<string> Enemies = new();

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