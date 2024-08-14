using System.Linq.Dynamic.Core;

namespace Insure.X.Domain.Extensions;

/// <summary>
/// IQueryableExtensions class
/// </summary>
public static class IQueryableExtensions
{
    /// <summary>
    /// FilterByParams
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="searchTerm"></param>
    /// <param name="propertyNames"></param>
    /// <returns></returns>
    public static IQueryable<T> FilterByParams<T>(this IQueryable<T> source, 
        string? searchTerm,
        string[] propertyNames)
    {
        try
        {
            if (string.IsNullOrEmpty(searchTerm) || propertyNames?.Any() != true)
                return source;

            var filters = propertyNames
                .Select(p => $"{p}.ToLower().Contains(@0)")
                .ToArray();

            var combinedFilter = string.Join(" || ", filters);

            return source.Where(combinedFilter, searchTerm);
        }
        catch(Exception exc)
        {
            Console.WriteLine($"{nameof(FilterByParams)}-{exc.Message}");
        }

        return source;
    }

    /// <summary>
    /// OrderByParams
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="sortField"></param>
    /// <param name="sortOrder"></param>
    /// <returns></returns>
    public static IQueryable<T> OrderByParams<T>(this IQueryable<T> source,
        string? sortField,
        string? sortOrder)
    {
        try
        {
            if (string.IsNullOrEmpty(sortField))
                return source;

            sortField = char.ToUpper(sortField[0]) + sortField[1..];
            sortOrder = (sortOrder ?? string.Empty).ToLower();

            string sortingExpression =
                $"{sortField} {(sortOrder == "asc" ? "ascending" : "descending")}";

            return DynamicQueryableExtensions.OrderBy(source, sortingExpression);
        }
        catch (Exception exc)
        {
            Console.WriteLine($"{nameof(OrderByParams)}-{exc.Message}");
        }

        return source;
    }

    /// <summary>
    /// PageByParams
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    public static IQueryable<T> PageByParams<T>(this IQueryable<T> source,
        int pageNumber,
        int pageSize)
    {
        try
        {
            pageNumber = pageNumber > 0 ? pageNumber : 1;
            pageSize = pageSize > 0 ? pageSize : 10;

            return source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }
        catch (Exception exc)
        {
            Console.WriteLine($"{nameof(PageByParams)}-{exc.Message}");
        }

        return source;
    }
}
