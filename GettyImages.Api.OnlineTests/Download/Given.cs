using GettyImages.Api.Search.Entity;
using TechTalk.SpecFlow;

namespace GettyImages.Api.Tests.Download
{
    [Binding]
    [Scope(Feature = "Downloads")]
    public class Given
    {
        /// <summary>
        /// </summary>
        [Given(@"I have sandbox user credentials")]
        public void GivenIHaveSandboxUserCredentials()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I specify (.*) file type")]
        public void WhenISpecifyAEpsFileType(string fileType)
        {
            var filetype = EnumEx.GetValueFromDescription<FileType>(fileType);
            ScenarioContext.Current.Set(filetype, "filetype");
            if (filetype.Equals(FileType.Eps))
            {
                ScenarioContext.Current.Set(4071, "height");
            }
            else if (filetype.Equals(FileType.Jpg))
            {
                ScenarioContext.Current.Set(1733, "height");
            }
        }

        [Given(@"a pixel height")]
        public void GivenAPixelHeight()
        {
            ScenarioContext.Current.Set(592, "height");
        }
    }
}