using System;
using GettyImages.Connect.Search;
using GettyImages.Connect.Search.Entity;
using TechTalk.SpecFlow;

namespace GettyImages.Connect.Tests.SearchForImages
{
    [Binding]
    [Scope(Feature = "Search for Images")]
    public class When
    {
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
                    Enum.Parse(typeof(EditorialSegment), segment));
        }

        [When(@"I specify a graphical (.*)")]
        public void WhenISpecifyIaGraphicalStyle(string style)
        {
            var styleEnum = EnumEx.GetValueFromDescription<GraphicalStyles>(style);
            ScenarioContext.Current.Get<SearchImages>("request")
                .WithGraphicalStyle((GraphicalStyles)Enum.Parse(typeof(GraphicalStyles), styleEnum.ToString()));
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
                .WithLicenseModel((LicenseModel)Enum.Parse(typeof(LicenseModel), licenseModel));
        }

        [When(@"I specify an orientation (.*)")]
        public void WhenISpecifyAnOrientation(string orientation)
        {
            ScenarioContext.Current.Get<SearchImages>("request")
                .WithOrientation((Orientation)Enum.Parse(typeof(Orientation), orientation));
        }

        [When(@"I specify a (.*) product type")]
        public void WhenISpecifyAProductType(string producttype)
        {
            var productType = EnumEx.GetValueFromDescription<ProductType>(producttype);
            ScenarioContext.Current.Get<SearchImages>("request")
               .WithProductType((ProductType)Enum.Parse(typeof(ProductType), productType.ToString()));
        }

        [When(@"I specify a (.*) number of people in image")]
        public void WhenISpecifyANoneNumberOfPeopleInImage(string peopleCount)
        {
            var peoplecount = EnumEx.GetValueFromDescription<NumberOfPeople>(peopleCount);
            ScenarioContext.Current.Get<SearchImages>("request")
                .WithNumberOfPeople((NumberOfPeople)Enum.Parse(typeof(NumberOfPeople), peoplecount.ToString()));
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
                  ScenarioContext.Current.Get<SearchImages>("request").WithKeywordId(64284).ExecuteAsync();
            ScenarioContext.Current.Add("task", task);
        }

        [When(@"I specify a (.*) file type")]
        public void WhenISpecifyAEpsFileType(string fileType)
        {
            var filetype = EnumEx.GetValueFromDescription<FileType>(fileType);
            ScenarioContext.Current.Get<SearchImages>("request").WithFileType((FileType)Enum.Parse(typeof(FileType), filetype.ToString()));
        }

        [When(@"I specify a event id")]
        public void WhenISpecifyAEventId()
        {
            var task =
                ScenarioContext.Current.Get<SearchImages>("request").WithEventId(518451).ExecuteAsync();
            ScenarioContext.Current.Add("task", task);
        }

        [When(@"I specify I want only prestige images")]
        public void WhenISpecifyIWantOnlyPrestigeImages()
        {
            ScenarioContext.Current.Get<SearchImages>("request").WithPrestigeContentOnly();
        }

        [When(@"I specify a (.*) age of people")]
        public void WhenISpecifyAnAgeOfPeople(string ageOfPeople)
        {
            var aop = EnumEx.GetValueFromDescription<AgeOfPeople>(ageOfPeople);
            ScenarioContext.Current.Get<SearchImages>("request").WithAgeOfPeople((AgeOfPeople)Enum.Parse(typeof(AgeOfPeople), aop.ToString()));
        }

        [When(@"I specify a (.*) composition")]
        public void WhenISpecifyAAbstractComposition(string composition)
        {
            var compositionEnum = EnumEx.GetValueFromDescription<Composition>(composition);
            ScenarioContext.Current.Get<SearchImages>("request").WithComposition((Composition)Enum.Parse(typeof(Composition), compositionEnum.ToString()));
        }

        [When(@"I specify an artist")]
        public void WhenISpecifyAnArtist()
        {
            ScenarioContext.Current.Get<SearchImages>("request").WithArtist("roman makhmutov");
        }

        [When(@"I specify an (.*) ethnicity")]
        public void WhenISpecifyAnEthnicity(string ethnicity)
        {
            var ethnicityEnum = EnumEx.GetValueFromDescription<Ethnicity>(ethnicity);
            ScenarioContext.Current.Get<SearchImages>("request").WithEthnicity((Ethnicity)Enum.Parse(typeof(Ethnicity), ethnicityEnum.ToString()));
        }

        [When(@"I specify a collection code")]
        public void WhenISpecifyACollectionCode()
        {
            ScenarioContext.Current.Get<SearchImages>("request").WithCollectionCode("WRI").WithCollectionCode("ARF");
        }

        [When(@"I specify an end date")]
        public void WhenISpecifyAnEndDate()
        {
            ScenarioContext.Current.Get<SearchImages>("request").WithDateTo("2015-04-01");
        }

        [When(@"I specify an start date")]
        public void WhenISpecifyAnStartDate()
        {
            ScenarioContext.Current.Get<SearchImages>("request").WithDateFrom("2015-04-01");
        }

        [When(@"I specify a (.*) collection code")]
        public void WhenISpecifyAwriCollectionCode(string code)
        {
            ScenarioContext.Current.Get<SearchImages>("request").WithCollectionCode(code);
        }

        [When(@"I specify a (.*) collection filter type")]
        public void WhenISpecifyAIncludeCollectionFilterType(string filter)
        {
            var filterEnum = EnumEx.GetValueFromDescription<CollectionFilter>(filter);
            ScenarioContext.Current.Get<SearchImages>("request").WithCollectionFilterType((CollectionFilter)Enum.Parse(typeof(CollectionFilter), filterEnum.ToString()));
        }

        [When(@"I specify a specific person")]
        public void WhenISpecifyASpecificPerson()
        {
            ScenarioContext.Current.Get<SearchImages>("request").WithSpecificPeople("Reggie Jackson");
        }
    }
}
