using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api.Images
{
    public class Images : ApiRequest
    {
        private const string Comma = ",";
        private const string IdsKey = "ids";
        private const string ImagePath = "/images/{0}";
        private const string ImageBatchPath = "/images";
        private readonly List<string> _imageIds = new List<string>();

        private Images(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static Images GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new Images(credentials, baseUrl, customHandler);
        }

        public override Task<dynamic> ExecuteAsync()
        {
            Method = "GET";
            var ids = string.Join(Comma, _imageIds);

            if (_imageIds.Count > 1)
            {
                QueryParameters.Add(IdsKey, ids);
                Path = ImageBatchPath;
            }
            else
            {
                Path = string.Format(ImagePath, ids);
            }

            return base.ExecuteAsync();
        }

        public Images WithId(string val)
        {
            _imageIds.Add(val);
            return this;
        }

        public Images WithIds(IEnumerable<string> val)
        {
            _imageIds.AddRange(val);
            return this;
        }

        public Images WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }

        public Images WithResponseFields(IEnumerable<string> values)
        {
            AddResponseFields(values);
            return this;
        }
    }
}