abstract class FigthableEntity
{
	[JsonInclude] public string Name;
	[JsonInclude] public string Description;
	[JsonInclude] public int Hp;
	[JsonInclude] public float Damage;
	[JsonInclude] public float Defense;
	[JsonInclude] public int StealChance;
	[JsonInclude] public List<string> savedInventory;

	public int totalDamage;
	public bool IsDefending;
	public List<Item> inventory = new();
	public int DamageScale = 1;

	int GetItemDefenseSum()
	{
		int sum = 0;
		foreach (Item item in inventory)
		{
			sum += item.DefenseBuff;
		}
		return sum;
	}

	int GetItemDamageSum()
	{
		int sum = 0;
		foreach (Item item in inventory)
		{
			sum += item.DamageBuff;
		}
		return sum;
	}

	//incombat options
	public void Attack(FigthableEntity target)
	{
		float targetDefense = target.Defense;
		float userDamage = Damage;

		if (S.debug) { System.Console.WriteLine("userATK: " + userDamage); System.Console.WriteLine("targetDEF: " + targetDefense); }



		// apply item buffs
		targetDefense += target.GetItemDefenseSum();
		userDamage += GetItemDamageSum();

		if (S.debug) { System.Console.WriteLine("efter items"); System.Console.WriteLine("userATK: " + userDamage); System.Console.WriteLine("targetDEF: " + targetDefense); }

		//apply block
		if (target.IsDefending) targetDefense *= 4;

		if (S.debug) { System.Console.WriteLine("efter block"); System.Console.WriteLine("targetDEF: " + targetDefense); }

		// damage roll för slop
		Random DamageRoll = new Random();
		int slop = DamageRoll.Next(5, 9);

		userDamage += slop;

		if (S.debug) { System.Console.WriteLine("efter damage roll"); System.Console.WriteLine("userATK: " + userDamage); }

		//inget får divideras med noll
		userDamage = Math.Max(1, userDamage);
		targetDefense = Math.Max(1, targetDefense);

		if (S.debug)
		{
			System.Console.WriteLine("efter noll prevention");
			System.Console.WriteLine("userATK: " + userDamage);
			System.Console.WriteLine("targetDEF: " + targetDefense);
		}

		float sumDamage = userDamage - targetDefense / 2;
		float multipliedDamage = Math.Max(1, userDamage / targetDefense);
		if (S.debug) { System.Console.WriteLine("sum: " + sumDamage); System.Console.WriteLine("mult: " + multipliedDamage); System.Console.WriteLine("damageScale " + DamageScale); }

		//calculate damage
		float realTotal = sumDamage + DamageScale * multipliedDamage;
		if (S.debug) { System.Console.WriteLine("total"); System.Console.WriteLine(realTotal); }

		totalDamage = Math.Max(1, (int)Math.Abs(realTotal));
		target.ResetDefend();

		//in case om det andra inte funkar
		//totalDamage = (int)MathF.Round(userDamage - targetDefense);
		//totalDamage = Math.Max(1, totalDamage);

		target.Hp -= totalDamage;
	}

	/// <summary>
	/// Give one item to the target and the target gives one item back.
	/// </summary>
	/// <param name="target">The target.</param>
	public void Trade(FigthableEntity target)
	{
		Console.WriteLine($"{Name} is trading with {target.Name}. {target.Name} can't refuse.");

		Console.ReadKey();
		if (target.inventory.Count < 1)
		{
			Console.WriteLine($"{target.Name} has no items to trade!");
			return;
		}

		if (inventory.Count < 1)
		{
			Console.WriteLine($"{Name} has no items to trade!");
			return;
		}

		WriteTradableItems();
		target.WriteTradableItems();

		MoveTradedItem(target, SelectTradeItemIndex(), target.SelectTradeItemIndex());
	}

	/// <summary>
	/// Writes the inventory for traiding.
	/// </summary>
	private void WriteTradableItems()
	{
		Console.WriteLine($"{Name}s invetory:");
		Console.WriteLine(S.ListToString(inventory));
	}

	/// <summary>
	/// Returns index for the seleced item.
	/// </summary>
	/// <returns>Index of item to trade.</returns>
	private int SelectTradeItemIndex()
	{
		Console.WriteLine($"Choose {Name}s item to give:");

		// Returns the index for the selected item.
		return S.GetIntFromConsole(1, inventory.Count) - 1;
	}

	/// <summary>
	/// Moves the item selected between target and player.
	/// </summary>
	/// <param name="target">The target to trade with.</param>
	/// <param name="playerIndex">The index for the item the player is going to give.</param>
	/// <param name="targetIndex">The index for the item the target is going to give.</param>
	private void MoveTradedItem(FigthableEntity target, int playerIndex, int targetIndex)
	{
		// Write what FightableEntity gave what item to whom.
		Console.WriteLine($"{Name} gave {inventory[playerIndex].Name} to {target.Name}");
		Console.WriteLine($"{target.Name} gave {target.inventory[targetIndex].Name} to {Name}");

		// Create temporary copies of the trading items.
		var playerTradeItem = inventory[playerIndex];
		var targetTradeitem = target.inventory[targetIndex];

		// Remove the items from the FightableEntitys inventories.
		target.inventory.RemoveAt(targetIndex);
		inventory.RemoveAt(playerIndex);

		// Give the FightableEntitys the traded tiems
		target.inventory.Add(playerTradeItem);
		inventory.Add(targetTradeitem);
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

		int itemToStealFromList = stealRnd.Next(0, target.inventory.Count);
		Item stolenItem = target.inventory[itemToStealFromList];
		target.inventory.RemoveAt(itemToStealFromList);
		inventory.Add(stolenItem);

		Console.WriteLine($"{Name} stole {stolenItem.Name}!");
	}

	public void Defend()
	{
		System.Console.WriteLine($"{Name} braced for impact");
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
			System.Console.WriteLine($"{Name} took the hit with ease");
			IsDefending = false;
		}
	}
}