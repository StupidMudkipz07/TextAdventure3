
abstract class FigthableEntity
{
    public string Name;
    public float Hp;
    public float Damage;
    public bool IsDefending;

    public abstract void Attack(FigthableEntity target);
    public abstract void Steal(FigthableEntity target, float stealChance);
    public abstract void Defend();

    List<Item> inventory;
}