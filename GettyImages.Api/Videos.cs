using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api
{
    public class Videos : ApiRequest
    {
        private const string MustSpecifyAtLeastOneImageIdMessage = "Must specify at least one image id.";
        private const string Comma = ",";
        private const string FieldsKey = "fields";
        private const string IdsKey = "ids";
        private const string VideosPath = "/videos/{0}";
        private const string VideosBatchPath = "/videos";
        private readonly List<string> _fields = new List<string>();
        private readonly List<string> _videoIds = new List<string>();

        private Videos(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
            Method = "GET";
        }

        internal static Videos GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new Videos(credentials, baseUrl, customHandler);
        }

        public Videos WithId(string val)
        {
            _videoIds.Add(val);
            return this;
        }

        public Videos WithIds(IEnumerable<string> val)
        {
            _videoIds.AddRange(val);
            return this;
        }

        public Videos WithResponseField(string value)
        {
            if (!_fields.Contains(value))
            {
                _fields.Add(value);
            }

            return this;
        }

        public override Task<dynamic> ExecuteAsync()
        {
            if (!_videoIds.Any())
            {
                throw new SdkException(MustSpecifyAtLeastOneImageIdMessage);
            }

            var ids = string.Join(Comma, _videoIds);

            if (_videoIds.Count > 1)
            {
                QueryParameters.Add(IdsKey, ids);
                Path = VideosBatchPath;
            }
            else
            {
                Path = string.Format(VideosPath, ids);
            }

            if (_fields.Any())
            {
                if (QueryParameters.ContainsKey(FieldsKey))
                {
                    QueryParameters[FieldsKey] = _fields;
                }
                else
                {
                    QueryParameters.Add(FieldsKey, _fields);
                }
            }

            return base.ExecuteAsync();
        }
    }
}