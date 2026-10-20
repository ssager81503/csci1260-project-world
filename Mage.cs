// Ranged Combatant
public class Mage : Hero, ISpellcaster
{

    private int _fizzleChance = 20;
    public Mage(string name) : base(name, 30)
    {
        LearnSkill("Fireball", 6);
        LearnSkill("Ice Spear", 4);
    }

    // Basic attack roll
    protected override int CalculateDamage()
    {
        if (_Fizzles())
            return 0;
        return Roll(3, 7) + BestSkillPower();
    }

    
    // I play wizard101 and theres a chance that spells fizzle.  Wanted to add same mechanic
    private bool _Fizzles()
    {
        return Roll(1, 100) <= _fizzleChance;
    }

    // Flavor
    public override string SpecialMove()
    {
        return $"{Name} moves their hands to form a spell and casts it!";
    }

    public string CastSpell()
    {
        if (_Fizzles())
            return $"{Name} The spell incantation forms but makes nothing but dust.  The spell fizzled!";
        return $"{Name} casts Fireball and throws it at the enemy!";
    }

    public override string Describe()
    {
        return base.Describe() + " [Mage]";
    }
}