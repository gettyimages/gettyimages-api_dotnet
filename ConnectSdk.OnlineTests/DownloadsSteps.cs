using System;
using System.Threading.Tasks;
using GettyImages.Connect.Search.Entity;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace GettyImages.Connect.Tests
{
    /// <summary>
    /// </summary>
    [Binding]
    [Scope(Feature = "Downloads")]
    public class DownloadsSteps
    {
        /// <summary>
        /// </summary>
        [Given(@"I have sandbox user credentials")]
        public void GivenIHaveSandboxUserCredentials()
        {
            ScenarioContext.Current.Pending();
        }

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

        [Given(@"I specify to auto download")]
        public void GivenISpecifyToAutoDownload()
        {
            ScenarioContext.Current.Set(true, "auto_download");
        }

        [Given(@"a pixel height")]
        public void GivenAPixelHeight()
        {
            ScenarioContext.Current.Set(592, "height");
        }

        [Then(@"I receive an error")]
        public void ThenIReceiveAnError()
        {
            Assert.Catch<Exception>(() =>
            {
                var task = ScenarioContext.Current.Get<Task<dynamic>>();
                task.Wait();
            });
        }

        [Then(@"the url has a (.*) file type")]
        public void ThenTheUrlHasTheFileType(string fileType)
        {
            var result = ScenarioContext.Current.Get<dynamic>("result");
            string uri = result.uri;
            Assert.IsTrue(uri.Contains(fileType), "wrong file_type is returned.");
        }

        [Then(@"the url will return the largest image")]
        public void ThenTheUrlWillReturnTheLargestImage()
        {
            var result = ScenarioContext.Current.Get<dynamic>("result");
            Uri downloadUri;
            Assert.IsTrue(Uri.TryCreate(result.uri.ToString(), UriKind.Absolute, out downloadUri),
                string.Format("String returned was not a valid URI: {0}", result.uri.ToString()));
        }

        /// <summary>
        /// </summary>
        [Then(@"the url for the image is returned")]
        public void ThenTheUrlForTheImageIsReturned()
        {
            var task = ScenarioContext.Current.Get<Task<dynamic>>();
            task.Wait();
            Assert.IsNotNull(task.Result);
            Assert.IsNotNullOrEmpty(task.Result.uri.ToString());
            ScenarioContext.Current.Set(task.Result, "result");
            Uri downloadUri;
            Assert.IsTrue(Uri.TryCreate(task.Result.uri.ToString(), UriKind.Absolute, out downloadUri),
                string.Format("String returned was not a valid URI: {0}", task.Result.uri.ToString()));
        }

        [Then(@"an image is returned")]
        public void ThenAnImageIsReturned()
        {
            var task = ScenarioContext.Current.Get<Task<dynamic>>();
            task.Wait();
            //Assert.IsNotNull(task.Result);
            //ScenarioContext.Current.Pending();
        }

        [Then(@"the url has the correct height")]
        public void ThenTheUrlHasTheCorrectHeight()
        {
            var result = ScenarioContext.Current.Get<dynamic>("result");
            Uri downloadUri;
            Assert.IsTrue(Uri.TryCreate(result.uri.ToString(), UriKind.Absolute, out downloadUri),
                string.Format("String returned was not a valid URI: {0}", result.uri.ToString()));
            string uri = result.uri;
            Assert.IsTrue(uri.Contains( "&b=RA=="), "wrong size is returned.");
        }
    }
}