struct Item
{
    [JsonInclude] public string Name;
    [JsonInclude] public string Description;

    public void PrintItem()
    {
        System.Console.WriteLine(Name);
        System.Console.WriteLine(Description);
    }
}