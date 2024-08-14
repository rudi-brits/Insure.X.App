using System.Text.RegularExpressions;

namespace Insure.X.Api.Utilities;

/// <summary>
/// SlugifyParameterTransformer implements <see cref="IOutboundParameterTransformer" />
/// </summary>
public class SlugifyParameterTransformer : IOutboundParameterTransformer
{
    /// <summary>
    /// _toLowerCaseRegex
    /// </summary>
    private static readonly Regex _toLowerCaseRegex = new("([a-z])([A-Z])", RegexOptions.Compiled);

    /// <summary>
    /// TransformOutbound
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public string? TransformOutbound(object? value)
    {
        if (value == null) { return null; }
        return _toLowerCaseRegex.Replace(value.ToString()!, "$1-$2").ToLower();
    }
}
