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

    void FillItemListFromString(AdolfKirkKöpingResidents enemy)
    {
        foreach (string savedItem in enemy.savedInventory)
        {
            //gör så att systemt inte kraschar om fienden inte har items
            if (!string.IsNullOrWhiteSpace(savedItem)) enemy.inventory.Add(itemManager.AllItems[savedItem]);
        }
    }

    //loads all the enemys to the dictionary
    public void InitializeEnemies()
    {
        foreach (AdolfKirkKöpingResidents enemy in LoadEnemies(resourceFilePath))
        {
            allEnemies.Add(enemy.Name, enemy);
            FillItemListFromString(enemy);
            //debug bullshit
            //enemy.PrintEnemy();
        }

    }

    public void StartNewFight(Player player, AdolfKirkKöpingResidents enemy)
    {
        Fight Kirkigaste = new Fight(player, enemy);
        Kirkigaste.ExecuteFight();
    }

    public FightManager(ItemManager itemManager)
    {
        this.itemManager = itemManager;
        InitializeEnemies();
    }

}