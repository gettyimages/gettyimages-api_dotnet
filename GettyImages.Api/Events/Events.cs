using System.Collections.Generic;
using System.Net.Http;

using GettyImages.Api.Models;

namespace GettyImages.Api.Events;

public class Events : ApiRequest<GetEventsResponse>
{

    private Events(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "GET";
        Path = "/events";

        AddResponseFields(new[]
        {
            "id", "child_event_count", "editorial_segments", "hero_image", "image_count", "location", "name", "start_date",
            "type"
        });
    }

    internal static Events GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new Events(credentials, baseUrl, customHandler);
    }

    public Events WithId(int value)
    {
        AddIds(new[] { value });
        return this;
    }

    public Events WithIds(IEnumerable<int> value)
    {
        AddIds(value);
        return this;
    }

    public Events WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }
}
