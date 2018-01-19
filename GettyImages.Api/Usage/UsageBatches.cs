using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api.Usage
{
    public class UsageBatches : ApiRequest
    {
        protected const string V3UsageBatchesPath = "/usage-batches";
        protected string AssetId { get; set; }

        private UsageBatches(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static UsageBatches GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new UsageBatches(credentials, baseUrl, customHandler);
        }

        public override async Task<dynamic> ExecuteAsync()
        {
            Method = "PUT";
            Path = V3UsageBatchesPath + "/" + AssetId;

            return await base.ExecuteAsync();
        }

        public UsageBatches WithId(string value)
        {
            AssetId = value;
            return this;
        }

        public UsageBatches WithRequest(string value)
        {
            BodyParameter = value;
            return this;
        }
    }
}
