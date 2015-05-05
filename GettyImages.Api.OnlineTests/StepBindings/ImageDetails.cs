using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GettyImages.Api.Tests;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace GettyImages.Api.OnlineTests.StepBindings
{
    [Binding]
    [Scope(Feature = "Image Details")]
    public class ImageDetails
    {
        [Given(@"I have an image id I want details on")]
        public void GivenIHaveAnImageIdIWantDetailsOn()
        {
            ScenarioContext.Current.Add("request",
                ScenarioCredentialsHelper.GetCredentials().Images().WithId("452777084"));
            ScenarioContext.Current.Add("imageid", "452777084");
        }

        [Given(@"I specify field (.*)")]
        public void GivenISpecifyField(string field)
        {
            ScenarioContext.Current.Get<Images>("request").WithResponseField(field);
        }

        [Given(@"I have a list of image ids I want details on")]
        public void GivenIHaveAListOfImageIdsIWantDetailsOn()
        {
            var idList = new List<string> {"452777084", "139839264", "477174619"};
            ScenarioContext.Current.Add("request",
                ScenarioCredentialsHelper.GetCredentials().Images().WithIds(idList));
            ScenarioContext.Current.Add("imageids", idList);

            ScenarioContext.Current.Get<Images>("request").WithResponseField("title");
        }

        [When(@"I retrieve image details")]
        [When(@"I retrieve details for the image")]
        [When(@"I retrieve details for the images")]
        public void WhenIRetrieveImageDetails()
        {
            ScenarioContext.Current.Add("task", ScenarioContext.Current.Get<Images>("request").ExecuteAsync());
        }

        [Then(@"I get a response back that has my image details")]
        public void ThenIGetAResponseBackThatHasMyImageDetails()
        {
            var task = ScenarioContext.Current["task"] as Task<dynamic>;
            task.Wait();
            Assert.AreEqual((string)ScenarioContext.Current["imageid"], task.Result.images[0].id.ToString());
        }

        [Then(@"the response contains (.*)")]
        public void ThenTheResponseContainsField(string field)
        {
            var task = ScenarioContext.Current.Get<Task<dynamic>>("task");
            task.Wait();

            Assert.NotNull(((JObject)task.Result.images[0]).Property(field));
        }

        [Then(@"I get a response back that has details for multiple images")]
        public void ThenIGetAResponseBackThatHasDetailsForMultipleImages()
        {
            var task = ScenarioContext.Current.Get<Task<dynamic>>("task");
            task.Wait();

            var imagesResponse = (JArray)task.Result.images;
            var idList = (List<string>)ScenarioContext.Current["imageids"];

            Assert.AreEqual(3, imagesResponse.Count);

            foreach (var item in imagesResponse.Children())
            {
                var properties = item.Children<JProperty>();
                var element = properties.FirstOrDefault(x => x.Name == "id");
                Assert.IsNotNull(element);

                var id = element.Value.ToString();
                Assert.AreEqual(true, idList.Contains(id));
            }
        }
    }
}