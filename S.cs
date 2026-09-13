global using System.Text.Json;

static class S
{

    public static void StartGameDialogue()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Clear();
        // slop dialogue
        System.Console.WriteLine("Hej kära spelare"); Console.ReadKey();
        System.Console.WriteLine("Jag är spelledaren av detta spel"); Console.ReadKey();
        System.Console.WriteLine("Jag har gjort spel i många år nu"); Console.ReadKey();
        System.Console.WriteLine("Jag har även vunnit SM långfinger dragkamp"); Console.ReadKey();
        System.Console.WriteLine("Och vet du vad?"); Console.ReadKey();
        System.Console.WriteLine("Jag har även skapat en 1:1 kopia av Darth Vader av snorkråkor och öronvax i mitt gara..."); Console.ReadKey();
        System.Console.WriteLine("juste"); Console.ReadKey();
        System.Console.WriteLine("Det är inte jag som är huvudpersonen av denna berättelse"); Console.ReadKey();
        System.Console.WriteLine("Det är du som är den viktiga nu!"); Console.ReadKey();
    }
    public static bool debug = false;

    public static bool Testing = false;
    public static string TestFilePath = "testLocations.json";

    public static string ListToString(List<string> list)
    {
        string output = "";
        for (int i = 0; i < list.Count; i++)
        {
            output += "\n   " + (i + 1) + ": " + list[i];
        }
        if (output == "") return "empty list";
        else return output;
    }

    public static string ListToString(List<Item> list)
    {
        string output = "";
        for (int i = 0; i < list.Count; i++)
        {
            output += "\n   " + (i + 1) + ": " + list[i].Name;
            output += "\n   " + list[i].Description;
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