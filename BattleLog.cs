// A log file for the battle. It writes lines to a file and closes the file when it is disposed.
// Disposing is safe to do twice, so the file is closed exactly once.
public class BattleLog : IDisposable
{
    private StreamWriter _writer;
    private bool _disposed = false;

    public BattleLog(string path)
    {
        if (path == null || path.Trim() == "")
            throw new ArgumentException("A log needs a file path.", nameof(path));

        _writer = new StreamWriter(path);
    }

    // Adds one line to the log file. Nothing is printed to the console here.
    public void Write(string message)
    {
        if (_disposed)
            throw new ObjectDisposedException(nameof(BattleLog), "The log is already closed.");

        _writer.WriteLine(message);
    }

    // Closes the file. The flag makes the second call do nothing.
    public void Dispose()
    {
        if (_disposed)
            return;

        _writer.WriteLine("--- Log closed ---");
        _writer.Dispose();
        _disposed = true;
    }
}