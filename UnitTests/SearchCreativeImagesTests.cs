using System.Reflection;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests
{
    public class SearchCreativeImagesTests
    {
        [Fact]
        public void SearchForCreativeImagesWithPhrase()
        {
            var testHandler = new TestHandler(new
            {
                images = new[]
                {
                    new {title="cat"}
                }
            });
            var response =  ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).Search().Images().Creative()
                .WithPhrase("cat").ExecuteAsync().Result;
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("search/images/creative");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("phrase=cat");
        }
    }
}
