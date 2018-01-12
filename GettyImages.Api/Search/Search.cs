using System.Net.Http;

namespace GettyImages.Api.Search
{
    public class Search
    {
        private readonly string _baseUrl;
        private readonly DelegatingHandler _customHandler;
        private readonly Credentials _credentials;

        private Search(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            _credentials = credentials;
            _baseUrl = baseUrl;
            _customHandler = customHandler;
        }

        internal static Search GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new Search(credentials, baseUrl, customHandler);
        }

        public IBlendedImagesSearch Images()
        {
            return SearchImages.GetInstance(_credentials, _baseUrl, _customHandler);
        }

        public IBlendedVideosSearch Videos()
        {
            return SearchVideos.GetInstance(_credentials, _baseUrl, _customHandler);
        }
    }
}