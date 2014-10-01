using System;
using System.Threading.Tasks;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace GettyImages.Connect.Tests
{
    /// <summary>
    /// </summary>
    [Binding]
    [Scope(Feature = "Downloads")]
    public class DownloadsSteps
    {
        /// <summary>
        /// </summary>
        [Given(@"I have sandbox user credentials")]
        public void GivenIHaveSandboxUserCredentials()
        {
            ScenarioContext.Current.Pending();
        }

        /// <summary>
        /// </summary>
        [Then(@"the url for the image is returned")]
        public void ThenTheUrlForTheImageIsReturned()
        {
            var task = ScenarioContext.Current.Get<Task<dynamic>>();
            task.Wait();
            Assert.IsNotNull(task.Result);
            Assert.IsNotNullOrEmpty(task.Result.uri.ToString());
            Uri downloadUri;
            Assert.IsTrue(Uri.TryCreate(task.Result.uri.ToString(), UriKind.Absolute, out downloadUri),
                string.Format("String returned was not a valid URI: {0}", task.Result.uri.ToString()));
        }

        [When(@"I request for any image to be downloaded")]
        public void WhenIRequestForAnyImageToBeDownloaded()
        {
            var client = ScenarioCredentialsHelper.GetCredentials();
            var task = client.Download().WithId("453126548").ExecuteAsync();
            ScenarioContext.Current.Set(task);
        }

        [Then(@"I receive an error")]
        public void ThenIReceiveAnError()
        {
            Assert.Catch<Exception>(() =>
            {
                var task = ScenarioContext.Current.Get<Task<dynamic>>();
                task.Wait();
            });
        }
    }
}