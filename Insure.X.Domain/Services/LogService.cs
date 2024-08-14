using Insure.X.Domain.Interfaces;

namespace Insure.X.Domain.Services;

/// <summary>
/// LogService implements <see cref="ILogService" />
/// </summary>
public class LogService : ILogService
{
    /// <summary>
    /// LogToConsole
    /// </summary>
    /// <param name="description"></param>
    /// <param name="message"></param>
    public void LogToConsole(string description, string message)
        => Console.WriteLine($"{description} - {message}");
}
