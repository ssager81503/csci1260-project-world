// Boss class it inherits from monster not combatant because it is a separate entity.  
// Wanna make him cast spells but idk if i will
public class Boss : Monster, ISpellcaster
{
    public Boss(string name, int maxHealth) : base(name, maxHealth)
    {
    }

    // Damage
    protected override int CalculateDamage()
    {
        return Roll(3, 5);
    }

    // Flavor
    public override string SpecialMove()
    {
        return $"{Name} roars and the whole dungeon shakes!";
    }

    public string CastSpell()
    {
        return $"{Name} hurls a bolt of dark fire!";
    }

    public override string Describe()
    {
        return base.Describe() + " [Boss]";
    }
}