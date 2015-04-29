using System;
using System.Linq;
using System.Threading.Tasks;
using GettyImages.Api.Search;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace GettyImages.Api.Tests
{
    [Binding]
    [Scope(Feature = "Search Results Paging")]
    public class SearchResultsPagingSteps
    {
        [Given(@"I configure my search for creative images")]
        public void GivenIConfigureMySearchForCreativeImages()
        {
            ScenarioContext.Current.Set(ScenarioCredentialsHelper.GetCredentials().Search().Images().Creative(),
                "request");
        }


        [Given(@"I search for dog")]
        public void GivenISearchForDog()
        {
            ScenarioContext.Current.Get<SearchImages>("request").WithPhrase("dog");
        }


        [Given(@"I specify (.*) number of items per page")]
        public void GivenISpecifyNumberOfItemsPerPage(int p0)
        {
            ScenarioContext.Current.Get<SearchImages>("request").WithPageSize(p0);
        }

        [Given(@"I want page (.*)")]
        public void GivenIWantPage(int p0)
        {
            ScenarioContext.Current.Add("pagesize", p0);
            ScenarioContext.Current.Get<SearchImages>("request").WithPage(p0);
        }


        [Then(@"the number of items returned matches (.*)")]
        public void ThenTheNumberOfItemsReturnedMatches(int p0)
        {
            var task = ScenarioContext.Current.Get<Task<dynamic>>();
            try
            {
                task.Wait();
                Assert.AreEqual(p0, task.Result.images.Count);
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

        [Then(@"the response has images")]
        public void ThenTheResponseHasImages()
        {
            var task = ScenarioContext.Current.Get<Task<dynamic>>();
            try
            {
                task.Wait();
                Assert.IsTrue(task.Result.images.Count > 0);
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


        [When(@"I retrieve the results")]
        public void WhenIRetrieveTheResults()
        {
            try
            {
                ScenarioContext.Current.Set(ScenarioContext.Current.Get<SearchImages>("request").ExecuteAsync());
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

        [When(@"I retrieve page (.*)")]
        public void WhenIRetrievePage(int p0)
        {
            try
            {
                ScenarioContext.Current.Set(
                    ScenarioContext.Current.Get<SearchImages>("request").WithPage(p0).ExecuteAsync());
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
    }
}