using System.Linq.Dynamic.Core;

namespace Insure.X.Domain.Extensions;

public static class IQueryableExtensions
{
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

    public static IQueryable<T> OrderByParams<T>(this IQueryable<T> source,
        string? sortField,
        string? sortOrder)
    {
        if (string.IsNullOrEmpty(sortField))
            return source;

        sortField = char.ToUpper(sortField[0]) + sortField.Substring(1);
        sortOrder = (sortOrder ?? string.Empty).ToLower();

        string sortingExpression = 
            $"{sortField} {(sortOrder == "asc" ? "ascending" : "descending")}";

        return DynamicQueryableExtensions.OrderBy(source, sortingExpression);
    }

    public static IQueryable<T> PageByParams<T>(this IQueryable<T> source,
        int pageNumber,
        int pageSize)
    {
        pageNumber = pageNumber > 0 ? pageNumber : 1;
        pageSize   = pageSize > 0 ? pageSize : 10;

        return source
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);
    }
}
