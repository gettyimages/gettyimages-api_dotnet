using System;
using System.Threading.Tasks;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace GettyImages.Connect.Tests.Download
{
    [Binding]
    [Scope(Feature = "Downloads")]
    public class Then
    {
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

        [Then(@"the url has the correct height")]
        public void ThenTheUrlHasTheCorrectHeight()
        {
            var result = ScenarioContext.Current.Get<dynamic>("result");
            Uri downloadUri;
            Assert.IsTrue(Uri.TryCreate(result.uri.ToString(), UriKind.Absolute, out downloadUri),
                string.Format("String returned was not a valid URI: {0}", result.uri.ToString()));
            string uri = result.uri;
            Assert.IsTrue(uri.Contains("&b=RA=="), "wrong size is returned.");
        }
    }
}
