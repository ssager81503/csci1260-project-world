// Basic warrior archetype.  Simple and easy
public class Warrior : Hero
{
    public Warrior(string name) : base(name, 40)
    {
        LearnSkill("Sword Slash", 4);
        LearnSkill("Block", 3);
        LearnSkill("Heavy Attack", 4);
    }

    // Default attack
    protected override int CalculateDamage()
    {
        return Roll(4, 8) + BestSkillPower();
    }

    // Lil text for flavor
    public override string SpecialMove()
    {
        return $"{Name} Blocks the attack reverberating some of the damage back to the attacker!";
    }

    public override string Describe()
    {
        return base.Describe() + " [Warrior]";
    }
}