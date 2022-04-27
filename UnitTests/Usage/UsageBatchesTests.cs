using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using GettyImages.Api.Models;
using Xunit;

namespace UnitTests.Usage;

public class UsageBatchesTests
{
    [Fact]
    public async Task UsageBatchesBasic()
    {
        var testHandler = TestUtil.CreateTestHandler();

        // var request = @"{
        //     'asset_usages': [
        //      {
        //         'asset_id': 'string',
        //         'quantity': 0,
        //         'usage_date': '2018-02-12T15:52:59.833Z'
        //     }
        //     ]
        // }";
        var request = new ReportUsageBatchRequest
        {
            AssetUsages = new[]
            {
                new AssetUsage
                {
                    Quantity = 10,
                    AssetId = "testasset",
                    UsageDate = DateTime.UtcNow
                }
            }
        };
        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).UsageBatches()
            .WithId("464423888").WithRequest(request).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("usage-batches/464423888");
        testHandler.Request.Method.Should().Be(HttpMethod.Put);
    }
}