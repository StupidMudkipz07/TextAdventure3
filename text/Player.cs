class Player : FigthableEntity
{
    public Player()
    {

    }

    public override void Attack(FigthableEntity target)
    {
        target.Hp -= attack;
    }



    public void SetName()
    {
        Console.WriteLine("What is your name?");
        name = Console.ReadLine();
    }



}