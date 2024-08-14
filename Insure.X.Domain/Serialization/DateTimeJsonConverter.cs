using Insure.X.Domain.Constants;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Insure.X.Domain.Serialization;

/// <summary>
/// DateTimeJsonConverter extends <see cref="JsonConverter" /> for <see cref="DateTime" />
/// </summary>
public class DateTimeJsonConverter : JsonConverter<DateTime>
{
    /// <summary>
    /// _format
    /// </summary>
    private readonly string _format;

    /// <summary>
    /// DateTimeJsonConverter constructor
    /// </summary>
    public DateTimeJsonConverter() : this(FormatConstants.DefaultDateFormat)
    {
    }

    /// <summary>
    /// DateTimeJsonConverter constructor
    /// </summary>
    /// <param name="format"></param>
    public DateTimeJsonConverter(string format)
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
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => DateTime.ParseExact(reader.GetString()!, _format, null);

    /// <summary>
    /// Write
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    /// <param name="options"></param>
    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString(_format));
}
