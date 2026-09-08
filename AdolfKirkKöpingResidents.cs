class AdolfKirkKöpingResidents : FigthableEntity
{
    public void PrintEnemy()
    {
        System.Console.WriteLine(Name);
        System.Console.WriteLine(Description);
        System.Console.WriteLine(Damage);
        System.Console.WriteLine(Hp);
        System.Console.WriteLine(StealChance);
        System.Console.WriteLine(S.ListToString(savedInventory));
    }

}
