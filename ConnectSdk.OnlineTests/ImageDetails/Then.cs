using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace GettyImages.Connect.Tests.ImageDetails
{
    [Binding]
    [Scope(Feature = "Image Details")]
    public class Then
    {
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
