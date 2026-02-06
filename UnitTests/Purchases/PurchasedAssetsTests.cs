using System;
using System.Threading.Tasks;
using System.Web;

using AwesomeAssertions;

using GettyImages.Api;

using Xunit;

namespace UnitTests.Purchases;

public class PurchasedAssetsTests
{
    [Fact]
    public async Task PurchasedAssetsBasic()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .PurchasedAssets().ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("purchased-assets");
    }

    [Fact]
    public async Task PurchasedAssetsWithEndDate()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var dateTo = DateTime.Parse("2015-04-01");
        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .PurchasedAssets().WithDateTo(dateTo).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("purchased-assets");
        testHandler.Request.RequestUri.AbsoluteUri.Should()
            .Contain($"date_to={HttpUtility.UrlEncode(dateTo.ToString()).ToUpper()}");
    }

    [Fact]
    public async Task PurchasedAssetsWithPage()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .PurchasedAssets().WithPage(3).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("purchased-assets");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page=3");
    }

    [Fact]
    public async Task PurchasedAssetsWithPageSize()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .PurchasedAssets().WithPageSize(50).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("purchased-assets");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page_size=50");
    }

    [Fact]
    public async Task PurchasedAssetsWithStartDate()
    {
        var testHandler = TestUtil.CreateTestHandler();

        var dateFrom = DateTime.Parse("2015-04-01");
        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .PurchasedAssets().WithDateFrom(dateFrom).ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("purchased-assets");
        testHandler.Request.RequestUri.AbsoluteUri.Should()
            .Contain($"date_from={HttpUtility.UrlEncode(dateFrom.ToString()).ToUpper()}");
    }
}
