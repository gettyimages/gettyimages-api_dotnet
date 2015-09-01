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
    [Scope(Feature = "Video Metadata")]
    public class VideoMetadata : StepDefinitionsBase
    {
        private string FirstVideoId = "543827485";
        private string SecondVideoId = "470984852";
        private string ThirdVideoId = "538808613";

        public VideoMetadata()
        {
            var videoSearch = GetApiClient().Search().Videos().WithPhrase("cat").ExecuteAsync().Result;
            var videos = ((JArray) videoSearch.videos).ToObject<List<TestVideoMetaData>>();
            
            FirstVideoId = videos.First().Id;
            SecondVideoId = videos.Skip(1).Take(1).First().Id;
            ThirdVideoId = videos.Skip(2).Take(1).First().Id;

            var request = GetApiClient().Videos();
            ScenarioContext.Current.Add("request", request);
        }

        [Given(@"a video id")]
        public void GivenAVideoId()
        {
            Request.WithId(FirstVideoId);
        }

        [Given(@"a list of video ids")]
        public void GivenAListOfVideoIds()
        {
            Request.WithIds(new[] {FirstVideoId, SecondVideoId, ThirdVideoId});
        }

        [Given(@"(.*) field is specified")]
        public void GivenLargestDownloadsFieldIsSpecified(string field)
        {
            Request.WithResponseField(field);
        }

        [Given(@"a non-existent video id")]
        public void GivenANon_ExistentVideoId()
        {
            Request.WithId("somevideoid");
        }

        [When(@"the video metadata request is executed")]
        public void WhenTheVideoMetadataRequestIsExecuted()
        {
            var task = Request.ExecuteAsync();
            ScenarioContext.Current.Add("task", task);
        }

        [Then(@"the video metadata is returned")]
        public void ThenTheVideoMetadataIsReturned()
        {
            var task = ScenarioContext.Current["task"] as Task<dynamic>;
            try
            {
                task.Wait();
                Assert.AreEqual(FirstVideoId, task.Result.id.ToString());
            }
            catch (AggregateException ex)
            {
                if (ex.InnerExceptions.Any(e => e.GetType() == typeof(OverQpsException)))
                {
                    Assert.Inconclusive("Over QPS");
                }
                else
                {
                    throw;
                }
            }
        }

        [Then(@"a list of video metadata is returned")]
        public void ThenAListOfMetadataIsReturned()
        {
            var task = ScenarioContext.Current["task"] as Task<dynamic>;
            try
            {
                task.Wait();
                Assert.That(task.Result.videos.Count > 0);
            }
            catch (AggregateException ex)
            {
                if (ex.InnerExceptions.Any(e => e.GetType() == typeof(OverQpsException)))
                {
                    Assert.Inconclusive("Over QPS");
                }
                else
                {
                    throw;
                }
            }
            
        }

        [Then(@"the (.*) field is returned")]
        public void ThenTheLargestDownloadFieldIsReturned(string field)
        {
            var task = ScenarioContext.Current["task"] as Task<dynamic>;
            task.Wait();
            Assert.IsTrue(((IDictionary<string, JToken>)task.Result).ContainsKey(field));
        }

        [Then(@"an exception is thrown")]
        public void ThenAnExceptionIsThrown()
        { 
            var task = ScenarioContext.Current["task"] as Task<dynamic>;
            ScenarioContext.Current.Add("exception", Assert.Catch<AggregateException>(() => task.Wait()));
        }

        [Then(@"the exception explains that the video was not found")]
        public void ThenTheExceptionExplainsThatTheVideoWasNotFound()
        {
            Assert.IsTrue(
                ((SdkException) ScenarioContext.Current.Get<AggregateException>("exception").InnerExceptions.First())
                    .StatusCode == HttpStatusCode.NotFound);
        }

        private static Videos Request
        {
            get { return ScenarioContext.Current.Get<Videos>("request"); }
        }
    }
}
