// Record of some previous runs and stuff
public class RunRecord : IEquatable<RunRecord>, IComparable<RunRecord>
{
    private string _heroType;
    private string _bossName;
    private int _turns;

    public RunRecord(string heroType, string bossName, int turns)
    {
        if (heroType == null || heroType.Trim() == "")
            throw new ArgumentException("A run needs a hero type.", nameof(heroType));
        if (bossName == null || bossName.Trim() == "")
            throw new ArgumentException("A run needs a boss name.", nameof(bossName));
        if (turns <= 0)
            throw new ArgumentOutOfRangeException(nameof(turns), "Turns must be positive.");

        _heroType = heroType;
        _bossName = bossName;
        _turns = turns;
    }

    public string HeroType => _heroType;
    public string BossName => _bossName;
    public int Turns => _turns;

    public bool Equals(RunRecord other)
    {
        if (other == null)
            return false;
        return _heroType == other._heroType && _bossName == other._bossName;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as RunRecord);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_heroType, _bossName);
    }

    public int CompareTo(RunRecord other)
    {
        if (other == null)
            return 1;

        int result = _heroType.CompareTo(other._heroType);
        if (result != 0)
            return result;

        result = _bossName.CompareTo(other._bossName);
        if (result != 0)
            return result;

        return _turns.CompareTo(other._turns);
    }

    public string Describe()
    {
        return $"{_heroType} vs {_bossName}: {_turns} turns";
    }
}