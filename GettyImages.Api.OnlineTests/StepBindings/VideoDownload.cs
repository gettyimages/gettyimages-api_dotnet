using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace GettyImages.Api.OnlineTests.StepBindings
{
    [Binding]
    [Scope(Feature = "Video Download")]
    public class VideoDownload : StepDefinitionsBase
    {
        [Given(@"a download size")]
        public void GivenADownloadSize()
        {
            ScenarioContext.Current.Add("size", "hd1");
        }

        [When(@"I request for any video to be downloaded")]
        public void WhenIRequestForAnyVideoToBeDownloaded()
        {
            var request = GetApiClient().Download().Video().WithId("543827469");
            
            if (ScenarioContext.Current.ContainsKey("size"))
            {
                request.WithSize(ScenarioContext.Current.Get<string>("size"));
            }

            ScenarioContext.Current.Add("task", request.ExecuteAsync());
        }

        [Then(@"I receive an exception")]
        public void ThenIReceiveAnError()
        {
            ScenarioContext.Current.Add("exception", Assert.Catch<Exception>(() =>
            {
                var task = ScenarioContext.Current.Get<Task<dynamic>>("task");
                task.Wait();
            }));
        }

        [Then(@"I receive not authorized message")]
        public void ThenIReceiveNotAuthorizedMessage()
        {
            Assert.AreEqual(
                ((SdkException) ScenarioContext.Current.Get<AggregateException>("exception").InnerExceptions[0])
                    .StatusCode,
                HttpStatusCode.Unauthorized);
        }

        [Then(@"the url for the video is returned")]
        public void ThenTheUrlForTheVideoIsReturned()
        {
            var task = ScenarioContext.Current.Get<Task<dynamic>>("task");
            task.Wait();
            Assert.NotNull(task.Result["uri"]);
        }

    }
}
