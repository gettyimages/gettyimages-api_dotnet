﻿using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using GettyImages.Api;
using Xunit;

namespace UnitTests.Images
{
    public class ImagesTests
    {
        [Fact]
        public async Task MultipleImagesBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var ids = new List<string>() { "882449540", "629219532" };

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .Images().WithIds(ids).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("ids=882449540%2C629219532");
        }

        [Fact]
        public async Task SingleImageBasic()
        {
            var testHandler = TestUtil.CreateTestHandler();

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .Images().WithId("882449540").ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("images/882449540");
        }

        [Fact]
        public async Task MultipleImagesWithResponseFields()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var ids = new List<string>() { "882449540", "629219532" };

            var fields = new List<string>() { "country", "id" };

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .Images().WithIds(ids).WithResponseFields(fields).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("images");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("ids=882449540%2C629219532");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("fields=country%2Cid");
        }

        [Fact]
        public async Task SingleImageWithResponseFields()
        {
            var testHandler = TestUtil.CreateTestHandler();

            var fields = new List<string>() { "country", "id" };

            await ApiClient.GetApiClientWithClientCredentials("apiKey", "apiSecret", testHandler)
                .Images().WithId("882449540").WithResponseFields(fields).ExecuteAsync();

            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("images/882449540");
            testHandler.Request.RequestUri.AbsoluteUri.Should().Contain("fields=country%2Cid");
        }
    }
}
