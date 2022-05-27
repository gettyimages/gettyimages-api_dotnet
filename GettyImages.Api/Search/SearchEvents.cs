using System.Net.Http;
using GettyImages.Api.Models;

namespace GettyImages.Api.Search;

public class Events : ApiRequest<SearchEventsResponse>
{
    private Events(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        AddResponseFields(new[]
        {
            "id", "child_event_count", "editorial_segments", "hero_image", "image_count", "keywords", "location",
            "name", "start_date", "type"
        });
        Method = "GET";
        Path = "/search/events";
    }

    internal static Events GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new Events(credentials, baseUrl, customHandler);
    }

    public Events WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }

    public Events WithGICountryCode(string value)
    {
        AddHeaderParameter(Constants.GICountryCode, value);
        return this;
    }

    public Events WithDateFrom(string value)
    {
        AddQueryParameter(Constants.DateFromKey, value);
        return this;
    }

    public Events WithDateTo(string value)
    {
        AddQueryParameter(Constants.DateToKey, value);
        return this;
    }

    public Events WithEditorialSegment(EditorialSegment value)
    {
        AddQueryParameter(Constants.EditorialSegmentKey, value);
        return this;
    }

    public Events WithPage(int value)
    {
        AddQueryParameter(Constants.PageKey, value);
        return this;
    }

    public Events WithPageSize(int value)
    {
        AddQueryParameter(Constants.PageSizeKey, value);
        return this;
    }

    public Events WithPhrase(string value)
    {
        AddQueryParameter(Constants.PhraseKey, value);
        return this;
    }

    public Events WithSortOrder(SortOrderEvent value)
    {
        AddQueryParameter(Constants.SortOrderKey, value);
        return this;
    }
}