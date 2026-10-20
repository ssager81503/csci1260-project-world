// Sorts these by least amount of turns to the most.
public class RunsByTurnsComparer : IComparer<RunRecord>
{
    public int Compare(RunRecord? x, RunRecord? y)
    {
        if (x == null && y == null)
            return 0;
        if (x == null)
            return -1;
        if (y == null)
            return 1;
        return x.Turns.CompareTo(y.Turns);
    }
}