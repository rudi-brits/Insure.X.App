namespace Insure.X.Domain.Models;

public class GridQueryParamsDto
{
    public string? Filter { get; set; }
    public string? SortField { get; set; }
    public string? SortOrder { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
