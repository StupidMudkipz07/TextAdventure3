
abstract class FigthableEntity
{
    public string name;
    public float Hp;
    public float attack;

    public abstract void Attack(FigthableEntity target);

    List<Item> inventory;
}