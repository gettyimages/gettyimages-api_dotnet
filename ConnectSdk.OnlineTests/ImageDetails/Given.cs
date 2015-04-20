using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace GettyImages.Connect.Tests.ImageDetails
{
    [Binding]
    [Scope(Feature = "Image Details")]
    public class Given
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
    }
}
