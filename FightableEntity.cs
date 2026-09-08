
using System.Collections;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

abstract class FigthableEntity
{
    [JsonInclude] public string Name;
    [JsonInclude] public float Hp;
    [JsonInclude] public float Damage;
    [JsonInclude] public float Defense;
    [JsonInclude] public List<string> savedInventory;

	public float totalDamage;
    public bool IsDefending;

    public void Attack(FigthableEntity target)
    {
		totalDamage = 0;

		if (target.Defense >= Damage)
			totalDamage = 1;
		else
			totalDamage += Damage - target.Defense;

		target.Hp -= totalDamage;
	}
    public void Steal(FigthableEntity target, float stealChance)
    {
		if (target.inventory.Count < 1)
		{
			Console.WriteLine("No items to steal!");
			return;
		}

		Random stealRnd = new Random();
		if (stealRnd.Next(1, 101) % 2 == 1)
		{
			Console.WriteLine($"{Name} attempted to steal but failed!");
			return;
		}

		int i = stealRnd.Next(0, inventory.Count);
		var stolenItem = target.inventory[i];
		target.inventory.RemoveAt(i);
		inventory.Add(stolenItem);
		Console.WriteLine($"{Name} stole {stolenItem.Name}!");
	}
    public void Defend()
    {
		Defense *= 2;
		IsDefending = true;
	}

	public void ResetDefend()
	{
		if (IsDefending)
		{
			Defense /= 2;
			IsDefending = false;
		}
	}

    public List<Item> inventory = new();

}