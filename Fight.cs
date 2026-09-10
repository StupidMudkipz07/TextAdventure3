class Fight
{
	public FigthableEntity playerEntity;
	public FigthableEntity opponentEntity;
	int turn = 0;

	FigthableEntity? Winner = null;

	public Fight(FigthableEntity player, FigthableEntity opponent)
	{
		playerEntity = player;
		opponentEntity = opponent;
	}

	bool AttackTarget(FigthableEntity attcker, FigthableEntity target)
	{
		attcker.Attack(target);
		Console.WriteLine(attcker.Name + " attacked " + target.Name + " for " + attcker.totalDamage + " damage");

		if (target.Hp <= 0)// target dör
		{
			Console.ReadKey();
			Console.WriteLine(target.Name + " was kirked out");
			return true;
		}
		else//target överlever
		{
			target.ResetDefend();
			return false;
		}
	}

	void PrintHp(FigthableEntity player, FigthableEntity opponent)
	{
		System.Console.WriteLine(player.Name + " has " + player.Hp + " health left");
		System.Console.WriteLine(opponent.Name + " has " + opponent.Hp + " health left");

	}

	void StartFight(FigthableEntity player, FigthableEntity opponent)
	{
		Random random = new Random();
		switch (random.Next(1, 4))
		{
			case 1:
				System.Console.WriteLine(opponent.Name + " kirkade fram ur skuggorna");
				break;
			case 2:
				System.Console.WriteLine($"{opponent.Name} kirkiade på {player.Name}'s balle");
				break;
			case 3:
				System.Console.WriteLine($"{opponent.Name} stirrar på {player.Name} med hat i sin blick");
				break;
			default:
				System.Console.WriteLine($"{player.Name} isnåg att {opponent.Name}'s båt var större än deras");
				break;
		}
		Console.ReadKey();
		System.Console.WriteLine("A battle ensues");
	}

	void FightAct(FigthableEntity user, FigthableEntity target, int option)
	{
		switch (option)
		{
			case 1:
				if (AttackTarget(user, target))
					Winner = user;
				break;
			case 2:
				user.Defend();
				break;
			case 3:
				user.Steal(target, user.StealChance);
				break;
			case 4:
				user.Inspect(target);
				break;
			default:
				break;
		}
	}

	int OpponentChoice()
	{
		Random opponentRandom = new Random();
		return opponentRandom.Next(1, 5);
	}

	int PlayerChoice()
	{
		Console.WriteLine("Välj en av de följade.");
		Console.WriteLine("1: Attack\n2: Defend\n3. Steal\n4: Inspect");
		Console.Write("Val: ");

		return S.GetIntFromConsole(1, 4);
	}

	void RunFight(FigthableEntity player, FigthableEntity opponent)
	{
		while (Winner == null)
		{
			Console.ReadKey();
			turn++;
			Console.WriteLine("\nturn: " + turn);
			PrintHp(player, opponent);

			FightAct(player, opponent, PlayerChoice());
			if (opponent.Hp > 0) //sluta fighten om fienden dör
			{
				Console.ReadKey();
				FightAct(opponent, player, OpponentChoice());
			}
		}
		Console.WriteLine("the winner is " + Winner.Name);
		if (Winner != player)
		{
			System.Console.WriteLine($"{player.Name} dog en plågsam död...");
			System.Console.WriteLine($"...i AdolfKirkKöping");
			Console.ReadLine();
			//här ska programmet stängas av
			Environment.Exit(0);
		}
	}



	public void ExecuteFight()
	{
		StartFight(playerEntity, opponentEntity);
		RunFight(playerEntity, opponentEntity);

	}
}