using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using GettyImages.Api;
using GettyImages.Api.Search;
using Xunit;

namespace UnitTests.HeaderAndBody;

public class HeadersTests
{
    [Fact]
    public void HeadersParameterTest()
    {
        var searchImages = SearchImagesCreative.GetInstance(null, null, null);

        searchImages.WithAcceptLanguage("fr");

        searchImages.WithGICountryCode("FRA");

        Assert.Equal("fr", searchImages.HeaderParameters[Constants.AcceptLanguage]);

        Assert.Equal("FRA", searchImages.HeaderParameters[Constants.GICountryCode]);
    }

    [Fact]
    public async void HeadersHandlerTest()
    {
        var h = new KeyValuePair<string, string>("Accept-Language", "fr");
        IEnumerable<KeyValuePair<string, string>> header = new List<KeyValuePair<string, string>> { h };
        var request = new HttpRequestMessage();
        var headerHandler = new TestHeadersHandler(header);

        try
        {
            await headerHandler.SendAsync(request, new CancellationToken());
        }
        catch (InvalidOperationException)
        {
            //No inner handler being assigned to HeadersHandler for test so catch needed for expected exception.
        }

        Assert.Equal("fr", request.Headers.AcceptLanguage.ToString());
    }
}