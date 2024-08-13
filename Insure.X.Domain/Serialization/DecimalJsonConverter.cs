using Insure.X.Domain.Constants;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Insure.X.Domain.Serialization;

public class DecimalJsonConverter : JsonConverter<decimal>
{
    private readonly string _format;

    public DecimalJsonConverter() : this(FormatConstants.DefaultDecimalFormat)
    {
    }

    public DecimalJsonConverter(string format)
    {
        _format = format;
    }

    public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => decimal.Parse(reader.GetString()!, CultureInfo.InvariantCulture);

    public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString(_format, CultureInfo.InvariantCulture));
}