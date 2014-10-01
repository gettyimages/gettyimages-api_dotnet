using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace GettyImages.Connect.Tests
{
    [Binding]
    [Scope(Feature = "Authorization")]
    public class AuthorizationSteps
    {
        [Given(@"a refresh token")]
        public void GivenARefreshToken()
        {
            var connect = ConnectSdk.GetConnectSdkWithResourceOwnerCredentials(
                    ScenarioContext.Current.Get<string>("apikey"),
                    ScenarioContext.Current.Get<string>("apisecret"),
                    Environment.GetEnvironmentVariable("ConnectSDK_UserName"),
                    Environment.GetEnvironmentVariable("ConnectSDK_UserPassword"));
            var refreshToken = connect.GetAccessToken().Result.RefreshToken;
            ScenarioContext.Current.Add("refreshtoken", refreshToken);
        }

        [Then(@"an access token is returned")]
        [Then(@"a token is returned")]
        public void ThenATokenIsReturned()
        {
            var task = ScenarioContext.Current["task"] as Task<Token>;
            try
            {
                task.Wait();
                Assert.IsNotNull(task.Result);
                Assert.IsNotNullOrEmpty(task.Result.AccessToken);
            }
            catch (AggregateException ex)
            {
                if (ex.InnerExceptions.Any(e => e.GetType() == typeof (OverQpsException)))
                {
                    Assert.Inconclusive("Over QPS");
                }
                else
                {
                    throw;
                }
            }
        }

        [When(@"I request an access token")]
        [When(@"I ask the sdk for an authentication token")]
        public void WhenIAskTheSdkForAnAuthenticationToken()
        {
            var client = ScenarioCredentialsHelper.GetCredentials();
            ScenarioContext.Current.Add("task", client.GetAccessToken());
        }
    }
}