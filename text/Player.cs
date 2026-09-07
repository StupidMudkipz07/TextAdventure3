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

    public override void Attack(FigthableEntity target)
    {
        target.Hp -= Damage;
    }  

    public override void Defend()
    {
        throw new NotImplementedException();
    }

    public override void Steal(FigthableEntity target, float stealChance)
    {
        throw new NotImplementedException();
    }

}