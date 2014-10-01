using System;
using TechTalk.SpecFlow;

namespace GettyImages.Connect.Tests
{
    [Binding]
    public class SharedGiven
    {
        public void GivenIHaveClientCredentials()
        {
            ScenarioContext.Current.Set(
                ConnectSdk.GetConnectSdkWithClientCredentials(
                    Environment.GetEnvironmentVariable("ConnectSDK_ApiKey"),
                    Environment.GetEnvironmentVariable("ConnectSDK_ApiSecret")));
        }

        public void GivenIHaveResourceOwnerCredentials()
        {
            ScenarioContext.Current.Set(
                ConnectSdk.GetConnectSdkWithResourceOwnerCredentials(
                    Environment.GetEnvironmentVariable("ConnectSDK_ApiKey"),
                    Environment.GetEnvironmentVariable("ConnectSDK_ApiSecret"),
                    Environment.GetEnvironmentVariable("ConnectSDK_UserName"),
                    Environment.GetEnvironmentVariable("ConnectSDK_UserPassword")));
        }

        [Given(@"I have an apikey")]
        public void GivenIHaveAnApiKey()
        {
            ScenarioContext.Current.Set(Environment.GetEnvironmentVariable("ConnectSDK_ApiKey"), "apikey");
        }


        [Given(@"an apisecret")]
        public void GivenAnApisecret()
        {
            ScenarioContext.Current.Set(Environment.GetEnvironmentVariable("ConnectSDK_ApiSecret"), "apisecret");
        }

        [Given(@"a username")]
        public void GivenAUsername()
        {
            ScenarioContext.Current.Set(Environment.GetEnvironmentVariable("ConnectSDK_UserName"), "username");
        }

        [Given(@"a password")]
        public void GivenAPassword()
        {
            ScenarioContext.Current.Set(Environment.GetEnvironmentVariable("ConnectSDK_UserPassword"), "userpassword");
        }
    }
}