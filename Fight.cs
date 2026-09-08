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
        Console.WriteLine(attcker.Name + " attacked " + target.Name + " for " + attcker.Attack + " damage");
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
            System.Console.WriteLine("turn: " + turn);
            PrintHp(player,opponent);
            if (AttackTarget(opponent, player)) Winner = opponent;
            else if (AttackTarget(player, opponent)) Winner = player;
            else; 
        }
        System.Console.WriteLine("the winner is " + Winner.Name);
    }

    public void ExecuteFight()
    {
        StartFight(playerEntity,opponentEntity);
        RunFight(playerEntity,opponentEntity);

        
    }
}