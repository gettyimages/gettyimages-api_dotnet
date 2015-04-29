using NUnit.Framework;
using TechTalk.SpecFlow;

namespace GettyImages.Api.Tests
{
    internal class ScenarioCredentialsHelper
    {
        public static ApiClient GetCredentials()
        {
            if (ScenarioContext.Current.ContainsKey("apikey")
                && ScenarioContext.Current.ContainsKey("apisecret")
                && ScenarioContext.Current.ContainsKey("refreshtoken"))
            {
                return ApiClient.GetApiClientWithRefreshToken(ScenarioContext.Current.Get<string>("apikey"),
                    ScenarioContext.Current.Get<string>("apisecret"),
                    ScenarioContext.Current.Get<string>("refreshtoken"));
            }

            if (ScenarioContext.Current.ContainsKey("apikey")
                && ScenarioContext.Current.ContainsKey("apisecret")
                && !ScenarioContext.Current.ContainsKey("username"))
            {
                return ApiClient.GetApiClientWithClientCredentials(
                    ScenarioContext.Current.Get<string>("apikey"),
                    ScenarioContext.Current.Get<string>("apisecret"));
            }

            if (ScenarioContext.Current.ContainsKey("apikey")
                && ScenarioContext.Current.ContainsKey("apisecret")
                && ScenarioContext.Current.ContainsKey("username")
                && ScenarioContext.Current.ContainsKey("userpassword"))
            {
                return ApiClient.GetApiClientWithResourceOwnerCredentials(
                    ScenarioContext.Current.Get<string>("apikey"),
                    ScenarioContext.Current.Get<string>("apisecret"),
                    ScenarioContext.Current.Get<string>("username"),
                    ScenarioContext.Current.Get<string>("userpassword"));
            }

            Assert.Fail(
                "Unable to determine which credentials to use. Did you include the proper steps in your scenario?");

            return null;
        }
    }
}