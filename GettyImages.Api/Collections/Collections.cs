using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api.Collections
{
    public class Collections : ApiRequest
    {
        protected const string V3CollectionsPath = "/collections";

        private Collections(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static Collections GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new Collections(credentials, baseUrl, customHandler);
        }

        public override async Task<dynamic> ExecuteAsync()
        {
            Method = "GET";
            Path = V3CollectionsPath;

            return await base.ExecuteAsync();
        }

        public Collections WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }
    }
}
