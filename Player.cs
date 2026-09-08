class Player : FigthableEntity
{
    public Player()
    {

    }

      public void SetName()
    {
        Console.WriteLine("What is your name?");
        Name = Console.ReadLine();
    }

}