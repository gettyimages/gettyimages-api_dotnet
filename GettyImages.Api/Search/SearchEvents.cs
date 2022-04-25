using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Entity;
using GettyImages.Api.Models;

namespace GettyImages.Api.Search
{
    public class Events : ApiRequest<EventsSearchResult>
    {
        protected const string V3SearchEventsPath = "/search/events";

        private Events(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static Events GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new Events(credentials, baseUrl, customHandler);
        }

        public override async Task<EventsSearchResult> ExecuteAsync()
        {
            Method = "GET";
            Path = V3SearchEventsPath;

            return await base.ExecuteAsync();
        }

        public Events WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }

        public Events WithDateFrom(string value)
        {
            AddQueryParameter(Constants.DateFromKey, value);
            return this;
        }

        public Events WithDateTo(string value)
        {
            AddQueryParameter(Constants.DateToKey, value);
            return this;
        }

        public Events WithEditorialSegment(EditorialSegment value)
        {
            AddQueryParameter(Constants.EditorialSegmentKey,  value);
            return this;
        }

        public Events WithResponseFields(IEnumerable<string> values)
        {
            AddResponseFields(values);
            return this;
        }

        public Events WithPage(int value)
        {
            AddQueryParameter(Constants.PageKey, value);
            return this;
        }

        public Events WithPageSize(int value)
        {
            AddQueryParameter(Constants.PageSizeKey, value);
            return this;
        }

        public Events WithPhrase(string value)
        {
            AddQueryParameter(Constants.PhraseKey, value);
            return this;
        }
    }
}
