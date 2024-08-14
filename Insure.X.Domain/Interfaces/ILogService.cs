namespace Insure.X.Domain.Interfaces;

/// <summary>
/// ILogService
/// </summary>
public interface ILogService
{
    /// <summary>
    /// LogToConsole
    /// </summary>
    /// <param name="description"></param>
    /// <param name="message"></param>
    void LogToConsole(string description, string message);
}
