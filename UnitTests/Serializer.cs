using System.Text.Json;
using System.Text.Json.Serialization;

namespace UnitTests;

static internal class Serializer
{
    public static T Deserialize<T>(string requestString)
    {
        return JsonSerializer.Deserialize<T>(requestString, new JsonSerializerOptions
        {
            PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy(),
            Converters = { new JsonStringEnumConverter() }
        });
    }
}