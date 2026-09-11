class Player : FigthableEntity
{
    public Player()
    {
        { Hp = 300; Damage = 444; Defense = 444; StealChance = 100; }

        SetName();
        Console.WriteLine("hej " + Name);
        Console.ReadKey();
        SetDescription();
        Console.WriteLine("Idag ska du få höra historien om AdolfKirkKöping!");
        Console.ReadKey();
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