using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api;

internal static class HttpResponseMessageExtensions
{
    internal static async Task HandleResponseAsync(this HttpResponseMessage httpResponse)
    {
        if (!httpResponse.IsSuccessStatusCode)
        {
            await SdkException.GenerateSdkExceptionAsync(httpResponse);
        }
    }

    internal static async Task<T> HandleGetContentResponseAsync<T>(this HttpResponseMessage httpResponse)
    {
        if (!httpResponse.IsSuccessStatusCode)
        {
            await SdkException.GenerateSdkExceptionAsync(httpResponse);
        }

        var stream = await httpResponse.Content.ReadAsStreamAsync();
        return await Serializer.DeserializeAsync<T>(stream);
    }
}
