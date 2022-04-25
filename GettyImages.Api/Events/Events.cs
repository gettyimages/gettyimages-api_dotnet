using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Models;

namespace GettyImages.Api.Events
{
    public class Events : ApiRequest<GetEventsResponse>
    {
        private const string Comma = ",";
        private const string IdsKey = "ids";
        private const string EventPath = "/events/{0}";
        private const string EventBatchPath = "/events";
        private readonly List<int> _eventIds = new List<int>();

        private Events(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
            Method = "GET";
        }

        internal static Events GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new Events(credentials, baseUrl, customHandler);
        }

        public override Task<GetEventsResponse> ExecuteAsync()
        {
            var ids = string.Join(Comma, _eventIds);

            if (_eventIds.Count > 1)
            {
                QueryParameters.Add(IdsKey, ids);
                Path = EventBatchPath;
            }
            else
            {
                Path = string.Format(EventPath, ids);
            }

            return base.ExecuteAsync();
        }

        public Events WithId(int val)
        {
            _eventIds.Add(val);
            return this;
        }

        public Events WithIds(IEnumerable<int> val)
        {
            _eventIds.AddRange(val);
            return this;
        }

        public Events WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }

        public Events WithResponseFields(IEnumerable<string> values)
        {
            AddResponseFields(values);
            return this;
        }
    }
}
