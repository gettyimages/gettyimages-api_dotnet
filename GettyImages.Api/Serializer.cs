using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GettyImages.Api;

public static class Serializer
{
    private static readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy(),
        Converters = { new JsonStringEnumConverter() }
    };

    public static T Deserialize<T>(string requestString)
    {
        return JsonSerializer.Deserialize<T>(requestString, _jsonSerializerOptions);
    }

    public static async Task<T> DeserializeAsync<T>(Stream stream)
    {
        return await JsonSerializer.DeserializeAsync<T>(stream, _jsonSerializerOptions);
    }

    public static string Serialize(object value)
    {
        return JsonSerializer.Serialize(value, _jsonSerializerOptions);
    }

    public static async Task SerializeAsync(Stream stream, object value)
    {
        await JsonSerializer.SerializeAsync(stream, value, _jsonSerializerOptions);
    }
}