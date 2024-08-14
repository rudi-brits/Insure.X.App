namespace Insure.X.Domain.Models;

/// <summary>
/// PagedResultDto
/// </summary>
/// <typeparam name="T"></typeparam>
public class PagedResultDto<T>
{
    /// <summary>
    /// Data
    /// </summary>
    public T Data { get; set; }
    /// <summary>
    /// TotalRecords
    /// </summary>
    public int TotalRecords { get; set; }

    /// <summary>
    /// PagedResultDto constructor
    /// </summary>
    /// <param name="data"></param>
    /// <param name="totalRecords"></param>
    public PagedResultDto(T data, int totalRecords)
    {
        Data = data;
        TotalRecords = totalRecords;
    }
}
