// A third way to sort run records: by boss name, then fewest turns first.
public class RunsByBossComparer : IComparer<RunRecord>
{
    public int Compare(RunRecord? x, RunRecord? y)
    {
        if (x == null && y == null)
            return 0;
        if (x == null)
            return -1;
        if (y == null)
            return 1;

        int result = x.BossName.CompareTo(y.BossName);
        if (result != 0)
            return result;
        return x.Turns.CompareTo(y.Turns);
    }
}