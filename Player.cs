class Player : FigthableEntity
{
    public Player()
    {
        SetName();
        Console.WriteLine("hej " + Name);
        Console.ReadKey();
        SetDescription();
        Console.WriteLine("Idag ska du utforska Adolf kirk köping!");
        Console.ReadKey();
    }


    void SetName()
    {
        Console.WriteLine("What is your name?");
        Name = Console.ReadLine();
    }

    void SetDescription()
    {
        Console.WriteLine("Kan du beskriva sig själv med några ord?");
        Description = Console.ReadLine();
    }

}