
using System.Runtime.InteropServices;

abstract class FigthableEntity
{
	[JsonInclude] public string Name;
	[JsonInclude] public string Description;
	[JsonInclude] public int Hp;
	[JsonInclude] public int Damage;
	[JsonInclude] public int Defense;
	[JsonInclude] public int StealChance;
	[JsonInclude] public List<string> savedInventory;

	public int totalDamage;
	public bool IsDefending;
	public List<Item> inventory = new();

	//incombat options
	public void Attack(FigthableEntity target)
	{
		totalDamage = 0;

		if (target.Defense >= Damage)
			totalDamage = 1;
		else
			totalDamage += Damage - target.Defense;

		target.Hp -= totalDamage;
	}

	public void Steal(FigthableEntity target, int stealChance)
	{
		Console.WriteLine($"{Name} attempted to steal from {target.Name}...");
		//kanske kan bytas ut mot thread.sleep
		Console.ReadKey();
		if (target.inventory.Count < 1)
		{
			Console.WriteLine("No items to steal!");
			return;
		}

		Random stealRnd = new Random();
		if (stealRnd.Next(1, 101) > stealChance)
		{
			Console.WriteLine($" but it failed!");
			return;
		}

		int itemToStealFromList = stealRnd.Next(0, inventory.Count);
		Item stolenItem = target.inventory[itemToStealFromList];
		target.inventory.RemoveAt(itemToStealFromList);
		inventory.Add(stolenItem);

		Console.WriteLine($"{Name} stole {stolenItem.Name}!");
	}

	public void Defend()
	{
		System.Console.WriteLine($"{Name} braced for impact");
		Defense *= 2;
		IsDefending = true;
	}

	public void Inspect(FigthableEntity target)
	{
		Console.WriteLine($"{Name} studied {target.Name}");
		Console.ReadKey();
		Console.WriteLine($"{Name}'s inspection informed him about this information:");
		Console.WriteLine(target.Description);
		if (target.inventory.Count > 0)
		{
			Console.WriteLine($"This was found in {target.Name}'s inventory:");
			Console.WriteLine(S.ListToString(target.inventory));
		}
	}

	public void ResetDefend()
	{
		if (IsDefending)
		{
			Defense /= 2;
			IsDefending = false;
		}
	}



}