using GettyImages.Api.Search.Entity;
using TechTalk.SpecFlow;

namespace GettyImages.Api.Tests.Download
{
    [Binding]
    [Scope(Feature = "Downloads")]
    public class When
    {
        [When(@"I request for any image to be downloaded")]
        public void WhenIRequestForAnyImageToBeDownloaded()
        {
            var client = ScenarioCredentialsHelper.GetCredentials();

            var request = client.Download().WithId("464423888");

            FileType filetype;
            ScenarioContext.Current.TryGetValue("filetype", out filetype);

            if (!filetype.Equals(FileType.None))
                request = request.WithFileType(filetype);

            bool autoDownload;
            ScenarioContext.Current.TryGetValue("auto_download", out autoDownload);
            request = request.WithAutoDownload(autoDownload);

            int height;
            ScenarioContext.Current.TryGetValue("height", out height);
            if (height > 0)
            {
                request = request.WithHeight(height);
            }

            var task = request.ExecuteAsync();
            ScenarioContext.Current.Set(task);
        }
    }
}