global using System.Text.Json;

static class S
{

    
    public static string ListToString(List<string> list)
    {
        string output = "";
        for (int i = 0; i < list.Count; i++)
        {
            output += "\n   " + list[i];
        }
        if (output == "") return "empty list";
        else return output;
    }

    public static int GetIntFromConsole()
    {
        int output;
        while (!int.TryParse(Console.ReadLine(), out output))
        {
            Console.WriteLine("input is not a integer");
        }
        return output;
    }

    public static int GetIntFromConsole(int minValue, int maxValue)
    {
        int output;
        while (1 == 1)
        {

            if (!int.TryParse(Console.ReadLine(), out output)) Console.WriteLine("input is not a integer");
            else
            {
                if (output > maxValue)
                {
                    Console.WriteLine("input is too big");
                }
                else if (output < minValue)
                {
                    Console.WriteLine("input is too small");
                }
                else return output;
            }
        }
    }

}