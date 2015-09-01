using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GettyImages.Api.OnlineTests.StepBindings.TestModels;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace GettyImages.Api.OnlineTests.StepBindings
{
    [Binding]
    [Scope(Feature = "Video Download")]
    public class VideoDownload : StepDefinitionsBase
    {
        private List<TestVideoMetaData> _videos;
        private string videoIdRequested = null;

        public VideoDownload()
        {
            //Got to search and find a valid download first, so lets do wthat.
            var videoSearch = GetApiClient().Search()
                                            .Videos()
                                            .WithPhrase("cat")
                                            //.WithResponseField("largest_downloads")
                                            .ExecuteAsync()
                                            .Result;
            _videos = ((JArray)videoSearch.videos).ToObject<List<TestVideoMetaData>>();
        }

        [Given(@"a download size")]
        public void GivenADownloadSize()
        {
            ScenarioContext.Current.Add("size", "comp");
        }

        [When(@"I request for any video to be downloaded")]
        public void WhenIRequestForAnyVideoToBeDownloaded()
        {
            if (videoIdRequested == null)
            {
                videoIdRequested = _videos.First().Id;
            }
            else
            {
                videoIdRequested = _videos.First(tvmd => tvmd.Id != videoIdRequested).Id;
            }
            
            var request = GetApiClient().Download().Video().WithId(videoIdRequested);
            
            if (ScenarioContext.Current.ContainsKey("size"))
            {
                request.WithSize(ScenarioContext.Current.Get<string>("size"));
            }

            if (ScenarioContext.Current.ContainsKey("task"))
            {
                ScenarioContext.Current["task"] = request.ExecuteAsync();
            }
            else
            {
                ScenarioContext.Current.Add("task", request.ExecuteAsync());
            }
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
            bool unexpectedExceptionCaught = false;
            int retryCount = 0;

            while (retryCount < 4)
            {
                try
                {
                    task.Wait();
                    Assert.NotNull(task.Result["uri"]);
                    return;
                }
                catch (AggregateException ae)
                {
                    if (ae.InnerExceptions.First().GetType() == typeof (UnauthorizedException))
                    {
                        //No Authorization for this video and size, try another 

                    }
                    else
                    {
                        unexpectedExceptionCaught = true;
                    }
                }

                if (unexpectedExceptionCaught)
                {
                    Assert.Fail("unexpected exception");
                    return;
                }

                retryCount++;
                WhenIRequestForAnyVideoToBeDownloaded();
            }
        }

    }
}
