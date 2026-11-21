namespace Adapter;

public abstract class BaseLogger
{
    public abstract void Info(string message);
    public abstract void Error(string message);
    public abstract void Debug(string message);
    public abstract void Warning(string message);
}

class Program
{
    static void Main(string[] args)
    {
        BaseLogger[] loggers =
        {
            new DebugLogger(),
            new ConsoleLogger(),
            new NullLoggerAdapter()
        };

        foreach (BaseLogger logger in loggers)
        {
            Console.WriteLine(logger.ToString());

            logger.Info("Info");
            logger.Error("Veateade");
            logger.Debug("Silumisteade");
            logger.Warning("Hoiatus");
        }
    }
}

public class DebugLogger : BaseLogger
{
    public override void Info(string message)
    {
        System.Diagnostics.Debug.WriteLine("INFO: " + message);
    }

    public override void Error(string message)
    {
        System.Diagnostics.Debug.WriteLine("ERROR: " + message);
    }

    public override void Debug(string message)
    {
        System.Diagnostics.Debug.WriteLine("DEBUG: " + message);
    }

    public override void Warning(string message)
    {
        System.Diagnostics.Debug.WriteLine("WARNING: " + message);
    }
}

public class ConsoleLogger : BaseLogger
{
    public override void Info(string message)
    {
        Console.WriteLine("INFO: " + message);
    }

    public override void Error(string message)
    {
        Console.WriteLine("ERROR: " + message);
    }

    public override void Debug(string message)
    {
        Console.WriteLine("DEBUG: " + message);
    }

    public override void Warning(string message)
    {
        Console.WriteLine("WARNING: " + message);
    }
}

public class NullLogger
{
    public void WriteDebug(string message) { }
    public void WriteInfo(string message) { }
    public void WriteWarning(string message) { }
    public void WriteError(string message) { }
}

public class NullLoggerAdapter : BaseLogger
{
    private readonly NullLogger _logger = new();

    public override void Info(string message)
    {
        _logger.WriteInfo(message);
    }

    public override void Error(string message)
    {
        _logger.WriteError(message);
    }

    public override void Debug(string message)
    {
        _logger.WriteDebug(message);
    }

    public override void Warning(string message)
    {
        _logger.WriteWarning(message);
    }
}