// Default monster, inherits from Combatant cause monsters fight.
public class Monster : Combatant
{
    public Monster(string name, int maxHealth) : base(name, maxHealth)
    {
    }

    // Normal attacks, might make monsters do specials might not
    protected override int CalculateDamage()
    {
        return Roll(2, 5);
    }

    // Flavor text
    public override string SpecialMove()
    {
        return $"{Name} lunges with a savage bite!";
    }

    public override string Describe()
    {
        return base.Describe() + " [Monster]";
    }
}