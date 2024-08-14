namespace Insure.X.Domain.Models;

/// <summary>
/// GridQueryParamsDto
/// </summary>
public class GridQueryParamsDto
{
    /// <summary>
    /// Filter
    /// </summary>
    public string? Filter { get; set; }
    /// <summary>
    /// SortField
    /// </summary>
    public string? SortField { get; set; }
    /// <summary>
    /// SortOrder
    /// </summary>
    public string? SortOrder { get; set; }
    /// <summary>
    /// PageNumber
    /// </summary>
    public int PageNumber { get; set; } = 1;
    /// <summary>
    /// PageSize
    /// </summary>
    public int PageSize { get; set; } = 10;
}
