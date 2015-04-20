using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GettyImages.Connect
{
    public class Images : ApiRequest
    {
        private const string MustSpecifyAtLeastOneImageIdMessage = "Must specify at least one image id.";
        private const string Comma = ",";
        private const string FieldsKey = "fields";
        private const string IdsKey = "ids";
        private const string ImagePath = "/images/{0}";
        private const string ImageBatchPath = "/images";
        private readonly List<string> _fields = new List<string>();
        private readonly List<string> _imageIds = new List<string>();

        private Images(Credentials credentials, string baseUrl)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
            Method = "GET";
        }

        internal static Images GetInstance(Credentials credentials, string baseUrl)
        {
            return new Images(credentials, baseUrl);
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

        public Images WithResponseField(string value)
        {
            if (!_fields.Contains(value))
            {
                _fields.Add(value);
            }

            return this;
        }

        public override Task<dynamic> ExecuteAsync()
        {
            if (!_imageIds.Any())
            {
                throw new SdkException(MustSpecifyAtLeastOneImageIdMessage);
            }

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