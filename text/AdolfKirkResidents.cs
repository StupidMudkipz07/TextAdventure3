class AdolfKirkResidents : FigthableEntity
{
    public static Dictionary<string, AdolfKirkResidents> allEnemies = new();

    public override void Attack(FigthableEntity target)
    {
        target.Hp -= attack;
    }

    public AdolfKirkResidents(string name)
    {
        this.name = name;
        allEnemies.Add(name,this);
    }
}
