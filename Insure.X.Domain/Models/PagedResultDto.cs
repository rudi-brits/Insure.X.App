namespace Insure.X.Domain.Models;

public class PagedResultDto<T>
{
    public T Data { get; set; }
    public int TotalRecords { get; set; }
}
