

struct Item
{
    [JsonInclude] public string Name;
    [JsonInclude] public string Description;

    void PrintItem()
    {
        System.Console.WriteLine(Name);
        System.Console.WriteLine(Description);
    }
}