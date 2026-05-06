namespace FrameworkApp.Services;

public class Logger
{
    public void Log(string msg)
    {
        Console.WriteLine($"[LOG] {msg}");
    }
}