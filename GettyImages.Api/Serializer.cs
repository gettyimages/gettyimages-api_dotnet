using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace GettyImages.Api;

public static class Serializer
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        Converters = { new JsonEnumMemberStringEnumConverter(JsonNamingPolicy.SnakeCaseLower) }
    };

    public static T Deserialize<T>(string requestString)
    {
        return JsonSerializer.Deserialize<T>(requestString, JsonSerializerOptions);
    }

    public static async Task<T> DeserializeAsync<T>(Stream stream)
    {
        return await JsonSerializer.DeserializeAsync<T>(stream, JsonSerializerOptions);
    }

    public static string Serialize(object value)
    {
        return JsonSerializer.Serialize(value, JsonSerializerOptions);
    }

    public static async Task SerializeAsync(Stream stream, object value)
    {
        await JsonSerializer.SerializeAsync(stream, value, JsonSerializerOptions);
    }
}
