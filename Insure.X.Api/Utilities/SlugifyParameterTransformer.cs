using System.Text.RegularExpressions;

namespace Insure.X.Api.Utilities;

public class SlugifyParameterTransformer : IOutboundParameterTransformer
{
    private static readonly Regex _toLowerCaseRegex = new Regex("([a-z])([A-Z])", RegexOptions.Compiled);

    public string? TransformOutbound(object? value)
    {
        if (value == null) { return null; }
        return _toLowerCaseRegex.Replace(value.ToString()!, "$1-$2").ToLower();
    }
}
