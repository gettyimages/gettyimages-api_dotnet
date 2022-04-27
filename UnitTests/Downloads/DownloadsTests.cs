using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using GettyImages.Api.Entity;
using Xunit;

namespace UnitTests.Downloads;

public class DownloadsTests
{
    [Fact]
    public async Task DownloadsBasic()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .Downloads()
            .ExecuteAsync();
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads");
    }

    [Fact]
    public async Task DownloadsWithCompanyDownloads()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .Downloads()
            .WithCompanyDownloads()
            .ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("company_downloads=True");
    }

    [Fact]
    public async Task DownloadsWithEndDate()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .Downloads()
            .WithEndDate("2015-04-01")
            .ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("end_date=2015-04-01");
    }

    [Fact]
    public async Task DownloadsWithPage()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler).Downloads()
            .WithPage(2)
            .ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page=2");
    }

    [Fact]
    public async Task DownloadsWithPageSize()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .Downloads()
            .WithPageSize(50)
            .ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("page_size=50");
    }

    [Fact]
    public async Task DownloadsWithProductType()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .Downloads()
            .WithProductType(ProductType.Easyaccess)
            .ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("product_type=easyaccess");
    }

    [Fact]
    public async Task DownloadsWithStartDate()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .Downloads()
            .WithStartDate("2015-04-01")
            .ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("start_date=2015-04-01");
    }

    [Fact]
    public async Task DownloadsWithStartDateAndUseTime()
    {
        var testHandler = TestUtil.CreateTestHandler();

        await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
            .Downloads()
            .WithStartDate("2015-04-01")
            .WithUseTime("true")
            .ExecuteAsync();

        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("downloads");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("start_date=2015-04-01");
        testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("use_time=true");
    }
}