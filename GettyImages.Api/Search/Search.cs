namespace GettyImages.Api.Search
{
    public class Search
    {
        private readonly string _baseUrl;
        private readonly Credentials _credentials;

        private Search(Credentials credentials, string baseUrl)
        {
            _credentials = credentials;
            _baseUrl = baseUrl;
        }

        internal static Search GetInstance(Credentials credentials, string baseUrl)
        {
            return new Search(credentials, baseUrl);
        }

        public IBlendedImagesSearch Images()
        {
            return SearchImages.GetInstance(_credentials, _baseUrl);
        }
    }
}