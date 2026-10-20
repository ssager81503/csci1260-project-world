// Main compiler? I think that is what Main.cs would be called a compiler
public class Program
{
    static void Main()
    {
        string outputPath = @"C:\Users\Wolfg\Desktop\C#\Project01\Combat.txt";
        File.Delete(outputPath);

        Random rng = new Random();

        // Part 1
        Console.WriteLine("=== 1. Classes and Relationships ===");
        File.AppendAllText(outputPath, "=== 1. Classes and Relationships ===" + Environment.NewLine);

        // Random Hero picker
        Hero hero;
        if (rng.Next(2) == 0)
            hero = new Warrior("Dwayne");
        else
            hero = new Mage("ShadowWizardMoneyGang");

        // Aggregation: Dungeon holder and just builds the monsters
        Dungeon dungeon = new Dungeon();
        dungeon.Add(new Monster("Skeever", 15));
        dungeon.Add(new Monster("Drauger", 20));
        dungeon.Add(new Boss("Dragon Priest", 50));

        Console.WriteLine(hero.Describe());
        File.AppendAllText(outputPath, hero.Describe() + Environment.NewLine);

        Console.WriteLine(dungeon.Describe());
        File.AppendAllText(outputPath, dungeon.Describe() + Environment.NewLine);

        // Constructors and exceptions
        try
        {
            Monster bad = new Monster("", 10);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Rejected: " + ex.Message);
            File.AppendAllText(outputPath, "Rejected: " + ex.Message + Environment.NewLine);
        }

        // Part 2
        Console.WriteLine("=== 2. Inheritance and Abstraction ===");
        File.AppendAllText(outputPath, "=== 2. Inheritance and Abstraction ===" + Environment.NewLine);

        // Autorunner.  Though I'de perfer a user input one but it is what it is
        string fightText = dungeon.RunFight(hero);
        Console.WriteLine(fightText);
        File.AppendAllText(outputPath, fightText + Environment.NewLine);

        Console.WriteLine(hero.Describe());      // shows the base call chain
        File.AppendAllText(outputPath, hero.Describe() + Environment.NewLine);

        // Part 3
        Console.WriteLine("=== 3. Polymorphism and Interfaces ===");
        File.AppendAllText(outputPath, "=== 3. Polymorphism and Interfaces ===" + Environment.NewLine);

        // Lists of the people
        List<Combatant> lineup = new List<Combatant>();
        lineup.Add(new Warrior("Dwayne"));
        lineup.Add(new Mage("ShadowWizardMoneyGang"));
        lineup.Add(new Monster("Skeever", 15));
        lineup.Add(new Boss("Dragon Priest", 50));
        foreach (Combatant c in lineup)
        {
            string move = c.SpecialMove();
            Console.WriteLine(move);
            File.AppendAllText(outputPath, move + Environment.NewLine);
        }

        // New Mage builder
        string mageCast = Cast(new Mage("WuTangDwayne"));
        Console.WriteLine(mageCast);
        File.AppendAllText(outputPath, mageCast + Environment.NewLine);

        string bossCast = Cast(new Boss("Dragon Priest", 50));
        Console.WriteLine(bossCast);
        File.AppendAllText(outputPath, bossCast + Environment.NewLine);

        // Part 4
        Console.WriteLine("=== 4. Built in Contracts and Collections ===");
        File.AppendAllText(outputPath, "=== 4. Built in Contracts and Collections ===" + Environment.NewLine);

        List<RunRecord> runs = new List<RunRecord>();
        runs.Add(new RunRecord("Warrior", "Dragon Priest", 14));
        runs.Add(new RunRecord("Mage", "Dragon Priest", 9));
        runs.Add(new RunRecord("Warrior", "Dragon Priest", 11));
        runs.Add(new RunRecord("Mage", "Drauger Deathlord", 12));

        HashSet<RunRecord> unique = new HashSet<RunRecord>(runs); // Idrk this tbh tutor said this is what I should add
        string countLine = "List count: " + runs.Count + ", HashSet count: " + unique.Count;
        Console.WriteLine(countLine);
        File.AppendAllText(outputPath, countLine + Environment.NewLine);

        runs.Sort();
        PrintRuns("Natural order:", runs, outputPath);
        runs.Sort(new RunsByTurnsComparer());
        PrintRuns("By turns:", runs, outputPath);
        runs.Sort(new RunsByBossComparer());
        PrintRuns("By boss:", runs, outputPath);

        // Part 5
        Console.WriteLine("=== 5. Exceptions and Files ===");
        File.AppendAllText(outputPath, "=== 5. Exceptions and Files ===" + Environment.NewLine);

        // Loader I think idk I never learned this stuff in 1250
        //List<RunRecord> loaded = LoadRuns(Path.Combine(AppContext.BaseDirectory, "runs.txt"));
        //Console.WriteLine("Loaded " + loaded.Count + " good records.");

        // thrower
        try
        {
            Monster ghost = new Monster("Ghost", -5);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Caught: " + ex.Message);
            File.AppendAllText(outputPath, "Caught: " + ex.Message + Environment.NewLine);
        }

        // Logger i think again 
        BattleLog log = new BattleLog("battle.log");
        try
        {
            using (log)
            {
                log.Write("The hero enters the dungeon.");
                log.Write("Something is about to go wrong...");
                throw new InvalidOperationException("The torch went out!");
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Caught: " + ex.Message);
            File.AppendAllText(outputPath, "Caught: " + ex.Message + Environment.NewLine);
        }
        log.Dispose();   // Chucks the file after

        string logText = File.ReadAllText("battle.log");
        Console.WriteLine(logText);
        File.AppendAllText(outputPath, logText + Environment.NewLine);
    }

    // Tries to make it so mages can cast spells
    static string Cast(ISpellcaster caster)
    {
        return caster.CastSpell();
    }

    // Prints out the list of stuff
    static void PrintRuns(string title, List<RunRecord> list, string path)
    {
        Console.WriteLine(title);
        File.AppendAllText(path, title + Environment.NewLine);

        foreach (RunRecord r in list)
        {
            string line = "  " + r.Describe();
            Console.WriteLine(line);
            File.AppendAllText(path, line + Environment.NewLine);
        }
    }

    // Reads the file one line at a time. A bad line is caught and skipped.
//     static List<RunRecord> LoadRuns(string path)
//     {
//         List<RunRecord> result = new List<RunRecord>();
//         string[] lines = File.ReadAllLines(path);
//         foreach (string line in lines)
//         {
//             try
//             {
//                 string[] parts = line.Split(',');
//                 int turns = int.Parse(parts[2]);
//                 result.Add(new RunRecord(parts[0], parts[1], turns));
//             }
//             catch (FormatException)
//             {
//                 Console.WriteLine("Skipped bad line (turns is not a number): " + line);
//             }
//             catch (ArgumentException ex)
//             {
//                 Console.WriteLine("Skipped bad line (" + ex.Message + "): " + line);
//             }
//         }
//         return result;
//     }
 }