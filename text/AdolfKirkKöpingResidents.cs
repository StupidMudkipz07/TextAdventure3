class AdolfKirkKöpingResidents : FigthableEntity
{
    public static Dictionary<string, AdolfKirkKöpingResidents> allEnemies = new();
    
    static List<AdolfKirkKöpingResidents> LoadEnemies(string filePath)
    {
        string data = File.ReadAllText(filePath);

        return JsonSerializer.Deserialize<List<AdolfKirkKöpingResidents>>(data, new JsonSerializerOptions { IncludeFields = true }) ?? [];
    }

    //loads all the locations to the dictionary
    static void InitializeEnemies()
    {
        foreach (AdolfKirkKöpingResidents enemy in LoadEnemies("locations.json"))
        {
            allEnemies.Add(enemy.Name, enemy);

            //debug bullshit
            //location.PrintLocation();
        }
    }

    public AdolfKirkKöpingResidents(string name)
    {
        this.Name = name;
        allEnemies.Add(name, this);
    }

    public override void Attack(FigthableEntity target)
    {
        target.Hp -= Damage;
    }

    public override void Defend()
    {
        throw new NotImplementedException();
    }

    public override void Steal(FigthableEntity target, float stealChance)
    {
        throw new NotImplementedException();
    }


}
