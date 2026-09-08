class ItemManager
{
    public string resourceFilePath = "Items.json";

    public Dictionary<string, Item> allItems = new();

    string GetItemData(string filePath) => File.ReadAllText(filePath);

    List<Item> LoadItems(string input)
    {
        return JsonSerializer.Deserialize<List<Item>>(input, new JsonSerializerOptions { IncludeFields = true }) ?? [];
    }

    //loads all the enemys to the dictionary
    public void InitializeItems()
    {
        foreach (Item item in LoadItems(GetItemData(resourceFilePath)))
        {
            allItems.Add(item.Name, item);
            //debug bullshit
            // enemy.PrintEnemy();
        }
    }

}