// This inherits from the combatant class cause heroes are combatants.  Monster will inherit too.
public abstract class Hero : Combatant
{
    private List<Skill> _skills = new List<Skill>();

    protected Hero(string name, int maxHealth) : base(name, maxHealth)
    {
    }

    protected void LearnSkill(string skillName, int power)
    {
        _skills.Add(new Skill(skillName, power));
    }

    protected int BestSkillPower()
    {
        int best = 0;
        foreach (Skill s in _skills)
        {
            if (s.Power > best)
                best = s.Power;
        }
        return best;
    }

    public override string Describe()
    {
        string result = base.Describe() + " | Skills:";
        foreach (Skill s in _skills)
        {
            result += " " + s.Describe();
        }
        return result;
    }
}