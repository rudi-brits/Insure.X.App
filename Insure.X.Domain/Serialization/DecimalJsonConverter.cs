using Insure.X.Domain.Constants;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Insure.X.Domain.Serialization;

/// <summary>
/// DecimalJsonConverter extends <see cref="JsonConverter" /> for <see cref="decimal" />
/// </summary>
public class DecimalJsonConverter : JsonConverter<decimal>
{
    /// <summary>
    /// _format
    /// </summary>
    private readonly string _format;

    /// <summary>
    /// DecimalJsonConverter constructor
    /// </summary>
    public DecimalJsonConverter() : this(FormatConstants.DefaultDecimalFormat)
    {
    }

    /// <summary>
    /// DecimalJsonConverter constructor
    /// </summary>
    /// <param name="format"></param>
    public DecimalJsonConverter(string format)
    {
        _format = format;
    }

    /// <summary>
    /// Read
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="typeToConvert"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => decimal.Parse(reader.GetString()!, CultureInfo.InvariantCulture);

    /// <summary>
    /// Write
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    /// <param name="options"></param>
    public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString(_format, CultureInfo.InvariantCulture));
}