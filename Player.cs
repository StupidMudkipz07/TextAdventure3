class Player : FigthableEntity
{
    public Player()
    {
        { Hp = 300; Damage = 19; Defense = 12; StealChance = 67; }

        SetName();
        Console.WriteLine("hej " + Name);
        Console.ReadKey();
        SetDescription();
        Console.WriteLine("Idag ska du få höra historien om AdolfKirkKöping!");
        Console.ReadKey();
    }


    //Debug feature
    public void AddItem(string item, ItemManager itemManager)
    {
        inventory.Add(itemManager.AllItems[item]);
        System.Console.WriteLine($"{item} was added to the players inventory");
    }

    void SetName()
    {
        Console.WriteLine("Vad är ditt namn?");
        Name = Console.ReadLine();
    }

    void SetDescription()
    {
        Console.WriteLine("Kan du beskriva dig själv med några ord?");
        Description = Console.ReadLine();
    }

}