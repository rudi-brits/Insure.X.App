using System.Linq.Expressions;

namespace Insure.X.Domain.Extensions;

public static class IQueryableExtensions
{
    public static IQueryable<T> SearchByTermContainsOrElse<T>(this IQueryable<T> source, 
        string? searchTerm, 
        params Expression<Func<T, string>>[] properties)
    {
        if (string.IsNullOrEmpty(searchTerm) || properties?.Any() != true)
            return source;

        var parameter = Expression.Parameter(typeof(T), "e");
        Expression? combinedExpression = null;

        searchTerm = searchTerm.ToLower();

        foreach (var property in properties)
        {
            var propertyExpression = Expression.Invoke(property, parameter);

            var toLowerMethod           = typeof(string).GetMethod("ToLower", Type.EmptyTypes);
            var lowerPropertyExpression = Expression.Call(propertyExpression, toLowerMethod!);
            var searchTermExpression    = Expression.Constant(searchTerm);

            var containsMethod     = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var containsExpression = Expression.Call(lowerPropertyExpression, containsMethod!, searchTermExpression);

            combinedExpression = combinedExpression == null
                ? containsExpression
                : Expression.OrElse(combinedExpression, containsExpression);
        }

        if (combinedExpression == null)
            return source;

        var lambda = Expression.Lambda<Func<T, bool>>(combinedExpression, parameter);
        return source.Where(lambda);
    }
}
