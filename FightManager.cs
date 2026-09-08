class FightManager
{
    Dictionary<string, AdolfKirkKöpingResidents> allEnemies = new();
    
    List<AdolfKirkKöpingResidents> LoadEnemies(string filePath)
    {
        string data = File.ReadAllText(filePath);

        return JsonSerializer.Deserialize<List<AdolfKirkKöpingResidents>>(data, new JsonSerializerOptions { IncludeFields = true }) ?? [];
    }

    //loads all the enemys to the dictionary
    public void InitializeEnemies()
    {
        foreach (AdolfKirkKöpingResidents enemy in LoadEnemies("enemies.json"))
        {
            allEnemies.Add(enemy.Name, enemy);

            //debug bullshit
            enemy.PrintEnemy();
        }
    }

    public void StartFight(Player player, AdolfKirkKöpingResidents enemy)
    {
        Fight fight = new Fight(player,enemy);
    }

}