using System;
using TechTalk.SpecFlow;

namespace GettyImages.Api.Tests
{
    [Binding]
    public class SharedGiven
    {
        public void GivenIHaveClientCredentials()
        {
            ScenarioContext.Current.Set(
                ApiClient.GetApiClientWithClientCredentials(
                    Environment.GetEnvironmentVariable("GettyImagesApi_ApiKey"),
                    Environment.GetEnvironmentVariable("GettyImagesApi_ApiSecret")));
        }

        public void GivenIHaveResourceOwnerCredentials()
        {
            ScenarioContext.Current.Set(
                ApiClient.GetApiClientWithResourceOwnerCredentials(
                    Environment.GetEnvironmentVariable("GettyImagesApi_ApiKey"),
                    Environment.GetEnvironmentVariable("GettyImagesApi_ApiSecret"),
                    Environment.GetEnvironmentVariable("GettyImagesApi_UserName"),
                    Environment.GetEnvironmentVariable("GettyImagesApi_UserPassword")));
        }

        [Given(@"I have an apikey")]
        public void GivenIHaveAnApiKey()
        {
            ScenarioContext.Current.Set(Environment.GetEnvironmentVariable("GettyImagesApi_ApiKey"), "apikey");
        }


        [Given(@"an apisecret")]
        public void GivenAnApisecret()
        {
            ScenarioContext.Current.Set(Environment.GetEnvironmentVariable("GettyImagesApi_ApiSecret"), "apisecret");
        }

        [Given(@"a username")]
        public void GivenAUsername()
        {
            ScenarioContext.Current.Set(Environment.GetEnvironmentVariable("GettyImagesApi_UserName"), "username");
        }

        [Given(@"a password")]
        public void GivenAPassword()
        {
            ScenarioContext.Current.Set(Environment.GetEnvironmentVariable("GettyImagesApi_UserPassword"), "userpassword");
        }
    }
}