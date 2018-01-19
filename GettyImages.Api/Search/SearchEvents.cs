using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Entity;

namespace GettyImages.Api.Search
{
    public class Products : ApiRequest
    {
        protected const string V3SearchEventsPath = "/search/events";

        private Products(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static Products GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new Products(credentials, baseUrl, customHandler);
        }

        public override async Task<dynamic> ExecuteAsync()
        {
            Method = "GET";
            Path = V3SearchEventsPath;

            return await base.ExecuteAsync();
        }

        public Products WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }

        public Products WithDateFrom(string value)
        {
            AddQueryParameter(Constants.DateFromKey, value);
            return this;
        }

        public Products WithDateTo(string value)
        {
            AddQueryParameter(Constants.DateToKey, value);
            return this;
        }

        public Products WithEditorialSegment(EditorialSegment value)
        {
            AddEditorialSegment(value);
            return this;
        }

        public Products WithResponseFields(IEnumerable<string> values)
        {
            AddResponseFields(values);
            return this;
        }

        public Products WithPage(int value)
        {
            AddQueryParameter(Constants.PageKey, value);
            return this;
        }

        public Products WithPageSize(int value)
        {
            AddQueryParameter(Constants.PageSizeKey, value);
            return this;
        }

        public Products WithPhrase(string value)
        {
            AddQueryParameter(Constants.PhraseKey, value);
            return this;
        }
    }
}
