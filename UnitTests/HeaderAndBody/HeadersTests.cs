using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using GettyImages.Api;
using GettyImages.Api.Search;
using Xunit;

namespace UnitTests.HeaderAndBody
{
    public class HeadersTests
    {
        [Fact]
        public void HeadersParameterTest()
        {
            var searchImages = SearchImages.GetInstance(null, null, null);

            searchImages.WithAcceptLanguage("fr");

            Assert.Equal("fr", searchImages.HeaderParameters[Constants.AcceptLanguage]);
        }

        [Fact]
        public async void HeadersHandlerTest()
        {
            KeyValuePair<string, string> h = new KeyValuePair<string, string>("Accept-Language", "fr");
            IEnumerable<KeyValuePair<string, string>> header = new List<KeyValuePair<string, string>>() { h };
            HttpRequestMessage request = new HttpRequestMessage();
            TestHeadersHandler headerHandler = new TestHeadersHandler(header);
          
            try
            {
                await headerHandler.SendAsync(request, new CancellationToken());
            }
            catch (System.InvalidOperationException)
            {
                //No inner handler being assigned to HeadersHandler for test so catch needed for expected exception.
            }
            
            Assert.Equal("fr", request.Headers.AcceptLanguage.ToString());
        }
    }
}
