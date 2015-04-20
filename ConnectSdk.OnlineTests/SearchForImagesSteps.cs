using System;
using System.Linq;
using System.Threading.Tasks;
using GettyImages.Connect.Search;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace GettyImages.Connect.Tests
{
    /// <summary>
    /// </summary>
    [Binding]
    [Scope(Feature = "Search for Images")]
    public class SearchForImagesSteps
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


        [Then(@"only required return fields plus (.*) are returned")]
        public void ThenOnlyRequiredReturnFieldsPlusRequestedFieldAreReturned(string field)
        {
            var task = ScenarioContext.Current["task"] as Task<dynamic>;
            try
            {
                task.Wait();
                Assert.NotNull(((JObject) task.Result.images[0]).Property(field));
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


        [When(@"I configure my search for creative images")]
        public void WhenIConfigureMySearchForCreativeImages()
        {
            ScenarioContext.Current.Set(
                ScenarioCredentialsHelper.GetCredentials().Search().Images().Creative(), "request");
        }

        [When(@"I configure my search for editorial images")]
        public void WhenIConfigureMySearchForEditorialImages()
        {
            ScenarioContext.Current.Set(
                ScenarioCredentialsHelper.GetCredentials().Search().Images().Editorial(), "request");
        }

        [When(@"I configure my search for blended images")]
        public void WhenIConfigureMySearchForBlendedImages()
        {
            ScenarioContext.Current.Set(
                ScenarioCredentialsHelper.GetCredentials().Search().Images(), "request");
        }

        [When(@"I search for (.*)")]
        public void WhenISearchFor(string searchPhrase)
        {
            var task =
                ScenarioContext.Current.Get<SearchImages>("request").WithPhrase(searchPhrase).ExecuteAsync();
            ScenarioContext.Current.Add("task", task);
        }


        [When(@"I specify that I only want to return (.*) with my search results")]
        public void WhenISpecifyThatIOnlyWantToReturnFieldsWithMySearchResults(string field)
        {
            ScenarioContext.Current.Get<SearchImages>("request").WithResponseField(field);
        }

        [When(@"I specify (.*) editorial segment")]
        public void WhenISpecifyEditorialSegment(string segment)
        {
            var request = ScenarioContext.Current.Get<IEditorialImagesSearch>("request");
            request.WithEditorialSegment(
                (EditorialSegment)
                    Enum.Parse(typeof (EditorialSegment), segment));
        }

        [When(@"I specify a graphical (.*)")]
        public void WhenISpecifyIaGraphicalStyle(string style)
        {
            ScenarioContext.Current.Get<SearchImages>("request")
                .WithGraphicalStyle((GraphicalStyles) Enum.Parse(typeof (GraphicalStyles), style));
        }

        [When(@"I specify I want only embeddable images")]
        public void WhenISpecifyIWantOnlyEmbeddableImages()
        {
            ScenarioContext.Current.Get<SearchImages>("request").WithEmbedContentOnly();
        }

        [When(@"I specify I want to exclude images containing nudity")]
        public void WhenISpecifyIWantToExcludeImagesContainingNudity()
        {
            ScenarioContext.Current.Get<SearchImages>("request").WithExcludeNudity();
        }

        [When(@"I specify a license model (.*)")]
        public void WhenISpecifyALicenseModel(string licenseModel)
        {
            ScenarioContext.Current.Get<SearchImages>("request")
                .WithLicenseModel((LicenseModel) Enum.Parse(typeof (LicenseModel), licenseModel));
        }

        [When(@"I specify an orientation (.*)")]
        public void WhenISpecifyAnOrientation(string orientation)
        {
            ScenarioContext.Current.Get<SearchImages>("request")
                .WithOrientation((Orientation) Enum.Parse(typeof (Orientation), orientation));
        }

        [When(@"I specify a (.*) product type")]
        public void WhenISpecifyAProductType(string producttype)
        {
            ScenarioContext.Current.Get<SearchImages>("request")
               .WithProductType((ProductType) Enum.Parse(typeof (ProductType), producttype));
        }

        [When(@"I specify a (.*) number of people in image")]
        public void WhenISpecifyANoneNumberOfPeopleInImage(string peopleCount)
        {
            ScenarioContext.Current.Get<SearchImages>("request")
                .WithNumberOfPeople((NumberOfPeople) Enum.Parse(typeof (NumberOfPeople), peopleCount));
        }

        [When(@"I specify a location of (.*)")]
        public void WhenISpecifyALocationOfCalifornia(string location)
        {
            ScenarioContext.Current.Get<SearchImages>("request").WithLocation(location);
        }

        [When(@"I specify a keyword id")]
        public void WhenISpecifyAKeywordId()
        {
            var task =
                  ScenarioContext.Current.Get<SearchImages>("request").WithKeywordId( 64284 ).ExecuteAsync();
            ScenarioContext.Current.Add("task", task);
        }

        [When(@"I specify a (.*) file type")]
        public void WhenISpecifyAEpsFileType(string fileType)
        {
            ScenarioContext.Current.Get<SearchImages>("request").WithFileType((FileType)Enum.Parse(typeof(FileType), fileType));
        }

        [When(@"I specify a event id")]
        public void WhenISpecifyAEventId()
        {
            var task =
                ScenarioContext.Current.Get<SearchImages>("request").WithEventId(518451).ExecuteAsync();
            ScenarioContext.Current.Add("task", task);

        }
    }
}