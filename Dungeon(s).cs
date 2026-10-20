// Main thing that autoruns and stores combatants, heroes and monsters
public class Dungeon
{
    private List<Combatant> _enemies = new List<Combatant>();
    private int _maxTurns = 50;

    public void Add(Combatant enemy)
    {
        if (enemy == null)
            throw new ArgumentNullException(nameof(enemy), "The dungeon can't hold a missing enemy.");
        _enemies.Add(enemy);
    }

    public string Describe()
    {
        string result = "The dungeon holds " + _enemies.Count + " enemies:";
        foreach (Combatant enemy in _enemies)
        {
            result += "\n  " + enemy.Describe();
        }
        return result;
    }

    // Runs the program without user input
    public string RunFight(Hero hero)
    {
        string report = hero.Name + " enters the dungeon.";

        foreach (Combatant enemy in _enemies)
        {
            if (!hero.IsAlive)
                break;

            report += "\n\n" + enemy.Name + " appears!";
            report += _FightOne(hero, enemy);
        }

        if (hero.IsAlive)
            report += "\n\n" + hero.Name + " survives the dungeon with " + hero.Health + "/" + hero.MaxHealth + " HP.";
        else
            report += "\n\nThe dungeon claims " + hero.Name + ".";

        return report;
    }

    // The turn based section my tutor help implement
    private string _FightOne(Hero hero, Combatant enemy)
    {
        string text = "";
        int turn = 1;

        while (hero.IsAlive && enemy.IsAlive && turn <= _maxTurns)
        {
            text += "\n  Turn " + turn + ": " + hero.Attack(enemy);
            if (enemy.IsAlive)
                text += "\n  Turn " + turn + ": " + enemy.Attack(hero);
            turn++;
        }

        if (!enemy.IsAlive)
            text += "\n" + enemy.Name + " is defeated!";
        else if (!hero.IsAlive)
            text += "\n" + hero.Name + " has fallen!";
        else
            text += "\nNeither side can finish the other. The fight is a stalemate.";

        return text;
    }
}