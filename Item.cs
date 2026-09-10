struct Item
{
    [JsonInclude] public string Name;
    [JsonInclude] public string Description;
    [JsonInclude] public int DefenseBuff;
    [JsonInclude] public int DamageBuff;

    public void PrintItem()
    {
        System.Console.WriteLine(Name);
        System.Console.WriteLine(Description);
    }
}