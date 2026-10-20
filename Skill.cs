// Skills for Combatants
public class Skill
{
    private string _name;
    private int _power;

    public Skill(string name, int power)
    {
        if (name == null || name.Trim() == "")
            throw new ArgumentException("A skill needs a name.", nameof(name));
        if (power <= 0)
            throw new ArgumentOutOfRangeException(nameof(power), "Power must be positive.");

        _name = name;
        _power = power;
    }

    public string Name => _name;
    public int Power => _power;

    public string Describe()
    {
        return $"{_name} (power {_power})";
    }
}