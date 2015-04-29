using TechTalk.SpecFlow;

namespace GettyImages.Api.Tests.ImageDetails
{
    [Binding]
    [Scope(Feature = "Image Details")]
    public class When
    {
        [When(@"I retrieve image details")]
        [When(@"I retrieve details for the image")]
        [When(@"I retrieve details for the images")]
        public void WhenIRetrieveImageDetails()
        {
            ScenarioContext.Current.Add("task", ScenarioContext.Current.Get<Images>("request").ExecuteAsync());
        }
    }
}