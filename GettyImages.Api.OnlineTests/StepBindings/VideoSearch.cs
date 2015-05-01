using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettyImages.Api.Search;
using GettyImages.Api.Search.Entity;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace GettyImages.Api.OnlineTests.StepBindings
{
    [Binding]
    public class VideoSearch
    {
       

        [Given(@"a (.*) video search")]
        public void GivenA(string searchtype)
        {
            ApiClient client;
            if (ScenarioContext.Current.ContainsKey("username"))
            {
                client =
                    ApiClient.GetApiClientWithResourceOwnerCredentials(ScenarioContext.Current.Get<string>("apikey"),
                        ScenarioContext.Current.Get<string>("apisecret"),
                        ScenarioContext.Current.Get<string>("username"),
                        ScenarioContext.Current.Get<string>("userpassword"));
            }
            else
            {
                client = ApiClient.GetApiClientWithClientCredentials(ScenarioContext.Current.Get<string>("apikey"),
                    ScenarioContext.Current.Get<string>("apisecret"));
            }

            IVideosSearch search;
            switch (searchtype)
            {
                case "creative":
                    search = client.Search().Videos().Creative();
                    break;
                case "editorial":
                    search = client.Search().Videos().Editorial();
                    break;
                default:
                    search = client.Search().Videos();
                    break;
            }

            ScenarioContext.Current.Add("videosearch", search);
        }

        [Given(@"a search phrase")]
        public void GivenASearchPhrase()
        {
            VideosSearch.WithPhrase("cat");
        }

        [Given(@"(.*) field is specified")]
        public void GivenLargestDownloadsFieldIsSpecified(string field)
        {
            VideosSearch.WithResponseField(field);
        }

        [Given(@"age of people filter is specified")]
        public void GivenAgeOfPeopleFilterIsSpecified()
        {
            VideosSearch
                .WithAgeOfPeople(AgeOfPeople.Adult | AgeOfPeople.Child);
        }

        [Given(@"collection codes filter is specified")]
        public void GivenCollectionCodesFilterIsSpecified()
        {
            VideosSearch.WithCollectionCode("ONE");
            VideosSearch.WithCollectionFilterType(CollectionFilter.Include);

        }

        private static SearchVideos VideosSearch
        {
            get { return ScenarioContext.Current.Get<SearchVideos>("videosearch"); }
        }

        [Given(@"exclude nudity filter is specified")]
        public void GivenExcludeNudityFilterIsSpecified()
        {
            VideosSearch.WithExcludeNudity();
        }

        [Given(@"format filter is specified")]
        public void GivenFormatFilterIsSpecified()
        {
            VideosSearch.WithAvailableFormat("HD");
        }

        [Given(@"license model filter is specified")]
        public void GivenLicenseModelFilterIsSpecified()
        {
            VideosSearch.WithLicenseModel(LicenseModel.RightsReady);
        }

        [Given(@"page number is specified")]
        public void GivenPageNumberIsSpecified()
        {
            VideosSearch.WithPage(1);
        }

        [Given(@"page size is specified")]
        public void GivenPageSizeIsSpecified()
        {
            VideosSearch.WithPageSize(40);
        }

        [Given(@"product type filter is specified")]
        public void GivenProductTypeFilterIsSpecified()
        {
            VideosSearch.WithProductType(ProductType.Easyaccess);
        }

        [Given(@"sort order is specified")]
        public void GivenSortOrderIsSpecified()
        {
            VideosSearch.WithSortOrder("best");
        }

        [Given(@"specific people filter is specified")]
        public void GivenSpecificPeopleFilterIsSpecified()
        {
            VideosSearch.WithSpecificPeople("Russel Wilson");
        }

        [When(@"the video search is executed")]
        public void WhenTheVideoSearchIsExecuted()
        {
            var task = VideosSearch.ExecuteAsync();
            ScenarioContext.Current.Add("task", task);
        }


        [Then(@"the status is success")]
        public void ThenTheStatusIsSuccess()
        {
           var task = ScenarioContext.Current["task"] as Task<dynamic>;
           Assert.DoesNotThrow(() => task.Wait());
        }

        [Then(@"video search results are returned")]
        public void ThenVideoSearchResultsAreReturned()
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
            Assert.IsTrue(((IDictionary<string, JToken>)((JObject) task.Result)["videos"][0]).ContainsKey("largest_downloads"));
        }
    }
}
