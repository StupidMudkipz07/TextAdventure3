class Fight
{
    FigthableEntity playerEntity;
    FigthableEntity opponentEntity;
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
        if (target.Hp <= 0)
        {
            System.Console.WriteLine(target.Name + " was kirked out");
            return true;
        }
        else return false;
    }

    void PrintHp(FigthableEntity player, FigthableEntity opponent)
    {
        System.Console.WriteLine(player.Name + " has " + player.Hp + " health left");
        System.Console.WriteLine(opponent.Name + " has " + opponent.Hp + " health left");

    }

    void StartFight(FigthableEntity player, FigthableEntity opponent)
    {
        System.Console.WriteLine(opponent.Name + " kirkade fram ur skuggorna");
    }

    void RunFight(FigthableEntity player, FigthableEntity opponent)
    {
		while (Winner == null)
		{
			turn++;
			Console.WriteLine("\nturn: " + turn);
			OpponentChoice(player, opponent);
			player.ResetDefend();
			PlayerChoice(player, opponent);
			opponent.ResetDefend();
			PrintHp(player, opponent);
		}
		Console.WriteLine("the winner is " + Winner.Name);
	}

	public void OpponentChoice(FigthableEntity player, FigthableEntity opponent)
	{
		Random opponentRandom = new Random();

		switch (opponentRandom.Next(1, 4))
		{
			case 1:
				if (AttackTarget(opponent, player))
					Winner = opponent;
				break;
			case 2:
				opponent.Defend();
				break;
			case 3:
				opponent.Steal(player, 1f);
				break;
			default:
				break;
		}
	}

	public void PlayerChoice(FigthableEntity player, FigthableEntity opponent)
	{
		Console.WriteLine("Välj en av de följade.");
		Console.WriteLine("1: Attack\n2: Defend\n3. Steal");
		Console.Write("Val: ");

		int choicsInt = S.GetIntFromConsole();
		switch (choicsInt)
		{
			case 1:
				if (AttackTarget(player, opponent))
					Winner = player;
				break;
			case 2:
				player.Defend();
				break;
			case 3:
				player.Steal(opponent, 1f);
				break;
			default:
				break;
		}
	}


	public void ExecuteFight()
    {
        StartFight(playerEntity,opponentEntity);
        RunFight(playerEntity,opponentEntity);

        
    }
}