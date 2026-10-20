// This is the basic class to determine what is gonna pop up when the program starts.
// My goal here is to have multiple ones and the program rolls at the beginning to choose 
// What type of hero will fight. 
public abstract class Combatant
{
    private static Random _rng = new Random();
    private string _name;
    private int _maxHealth;
    private int _health;

    protected Combatant(string name, int maxHealth)
    {
        if (name == null || name.Trim() == "")
            throw new ArgumentException("A combatant needs a name.", nameof(name));
        if (maxHealth <= 0)
            throw new ArgumentOutOfRangeException(nameof(maxHealth), "Health must be positive.");

        _name = name;
        _maxHealth = maxHealth;
        _health = maxHealth;
    }

    public string Name => _name;
    public int Health => _health;
    public int MaxHealth => _maxHealth;
    public bool IsAlive => _health > 0;

    // Tries to separate normal damage and special move damage
    protected abstract int CalculateDamage();
    public abstract string SpecialMove();

    public string Attack(Combatant target)
    {
        int damage = CalculateDamage();
        string result = target.TakeDamage(damage);
        return $"{_name} hits {target.Name} for {damage}. {result}";
    }

    // Damage taker
    public string TakeDamage(int amount)
    {
        _health = Math.Max(0, _health - amount);
        return $"{_name} has {_health}/{_maxHealth} HP.";
    }
    public virtual string Describe()
    {
        return $"{_name} ({_health}/{_maxHealth} HP)";
    }

    // Keep rolling rolling rolling 
    protected int Roll(int low, int high)
    {
        return _rng.Next(low, high + 1);
    }
}