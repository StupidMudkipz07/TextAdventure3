class ItemManager
{
    public string resourceFilePath = "Items.json";
    public Dictionary<string, Item> AllItems = new();
    List<Item> LoadItems(string filePath)
    {
        string data = File.ReadAllText(filePath);

        return JsonSerializer.Deserialize<List<Item>>(data, new JsonSerializerOptions { IncludeFields = true }) ?? [];
    }

    //loads all the enemys to the dictionary
    public void InitializeItems()
    {
        foreach (Item item in LoadItems(resourceFilePath))
        {
            AllItems.Add(item.Name, item);
            //debug bullshit
            if(S.debug){item.PrintItem();}
        }
    }

    public ItemManager()
    {
        InitializeItems();
    }

}