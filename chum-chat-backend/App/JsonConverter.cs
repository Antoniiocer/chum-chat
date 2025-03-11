namespace chum_chat_backend.App;

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

public class IgnoreRepeatedReferencesConverter<T> : JsonConverter<T> where T : class
{
    private readonly HashSet<object> _serializedObjects = new();

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        if (value == null || _serializedObjects.Contains(value))
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
            return;
        }

        _serializedObjects.Add(value);
        JsonSerializer.Serialize(writer, value, options);
    }

    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return JsonSerializer.Deserialize<T>(ref reader, options);
    }
}
