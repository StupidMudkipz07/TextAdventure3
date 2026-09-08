
using System.Text.Json.Serialization;

abstract class FigthableEntity
{
    [JsonInclude] public string Name;
    [JsonInclude] public float Hp;
    [JsonInclude] public float Damage;
    [JsonInclude] public float Defense;
    [JsonInclude] public List<string> savedInventory;
    public bool IsDefending;

    public void Attack(FigthableEntity target)
    {
        
    }
    public void Steal(FigthableEntity target, float stealChance)
    {
        
    }
    public void Defend()
    {
        
    }

    public List<Item> inventory;

}