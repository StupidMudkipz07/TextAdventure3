class FightManager
{
    ItemManager itemManager;

    public string resourceFilePath = "enemies.json";

    public Dictionary<string, AdolfKirkKöpingResidents> allEnemies = new();

    List<AdolfKirkKöpingResidents> LoadEnemies(string filePath)
    {
        string data = File.ReadAllText(filePath);

        return JsonSerializer.Deserialize<List<AdolfKirkKöpingResidents>>(data, new JsonSerializerOptions { IncludeFields = true }) ?? [];
    }

    //loads all the enemys to the dictionary
    public void InitializeEnemies()
    {
        foreach (AdolfKirkKöpingResidents enemy in LoadEnemies(resourceFilePath))
        {
            allEnemies.Add(enemy.Name, enemy);
            //debug bullshit
            // enemy.PrintEnemy();
        }
    }

    public void StartNewFight(Player player, AdolfKirkKöpingResidents enemy)
    {
        Fight Kirkigaste = new Fight(player, enemy);
        Kirkigaste.ExecuteFight();
    }

}