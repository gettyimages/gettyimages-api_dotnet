using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace GettyImages.Connect.Tests.SearchForImages
{

    [Binding]
    [Scope(Feature = "Search for Images")]
    public class Then
    {
        [Then(@"I get a response back that has my images")]
        public void ThenIGetAResponseBackThatHasMyImages()
        {
            var task = ScenarioContext.Current["task"] as Task<dynamic>;
            try
            {
                task.Wait();
                Assert.That(task.Result.images.Count > 0);
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


        [Then(@"only required return fields plus (.*) are returned")]
        public void ThenOnlyRequiredReturnFieldsPlusRequestedFieldAreReturned(string field)
        {
            var task = ScenarioContext.Current["task"] as Task<dynamic>;
            try
            {
                task.Wait();
                Assert.NotNull(((JObject)task.Result.images[0]).Property(field));
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
    }
}
