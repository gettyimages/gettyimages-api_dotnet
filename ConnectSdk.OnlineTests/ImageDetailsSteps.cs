using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace GettyImages.Connect.Tests
{
    [Binding]
    [Scope(Feature = "Image Details")]
    public class ImageDetailsSteps
    {
        [Given(@"I have an image id I want details on")]
        public void GivenIHaveAnImageIdIWantDetailsOn()
        {
            ScenarioContext.Current.Add("request",
                ScenarioCredentialsHelper.GetCredentials().Images().WithId("452777084"));
            ScenarioContext.Current.Add("imageid", "452777084");
        }

        [Then(@"I get a response back that has my image details")]
        public void ThenIGetAResponseBackThatHasMyImageDetails()
        {
            var task = ScenarioContext.Current["task"] as Task<dynamic>;
            task.Wait();
            Assert.AreEqual((string) ScenarioContext.Current["imageid"], task.Result.images[0].id.ToString());
        }


        [When(@"I retrieve image details")]
        public void WhenIRetrieveImageDetails()
        {
            ScenarioContext.Current.Add("task", ScenarioContext.Current.Get<Images>("request").ExecuteAsync());
        }

        [Given(@"I specify field (.*)")]
        public void GivenISpecifyFieldCaption(string field)
        {
            ScenarioContext.Current.Get<Images>("request").WithResponseField(field);
        }

        [Then(@"the response contains (.*)")]
        public void ThenTheResponseContainsField(string field)
        {
            var task = ScenarioContext.Current.Get<Task<dynamic>>("task");
            task.Wait();

            Assert.NotNull(((JObject) task.Result.images[0]).Property(field));
        }
    }
}