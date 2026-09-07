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
        Console.WriteLine(attcker.name + " attacked " + target.name + " for " + attcker.attack + " damage");
        if (target.Hp <= 0)
        {
            System.Console.WriteLine(target.name + " was kirked out");
            return true;
        }
        else return false;
    }

    void PrintHp(FigthableEntity player, FigthableEntity opponent)
    {
        System.Console.WriteLine(player.name + " has " + player.Hp + " health left");
        System.Console.WriteLine(opponent.name + " has " + opponent.Hp + " health left");

    }

    void StartFight(FigthableEntity player, FigthableEntity opponent)
    {
        System.Console.WriteLine(opponent.name + " kirkade fram ur skuggorna");
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
        System.Console.WriteLine("the winner is " + Winner.name);
    }

    public void ExecuteFight()
    {
        StartFight(playerEntity,opponentEntity);
        RunFight(playerEntity,opponentEntity);
    }
}