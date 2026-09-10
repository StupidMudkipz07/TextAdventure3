class AdolfKirkKöpingResidents : FigthableEntity
{
    public void PrintEnemy()
    {
        Console.WriteLine(Name);
        Console.WriteLine(Description);
        Console.WriteLine(Damage);
        Console.WriteLine(Hp);
        Console.WriteLine(StealChance);
        Console.WriteLine(S.ListToString(savedInventory));
    }

}