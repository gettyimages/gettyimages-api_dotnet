using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api.AssetChanges
{
    public class ChangeSets : ApiRequest<Models.AssetChanges>
    {
        protected const string V3ChangeSetsPath = "/asset-changes/change-sets";

        private ChangeSets(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static ChangeSets GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new ChangeSets(credentials, baseUrl, customHandler);
        }

        public override async Task<Models.AssetChanges> ExecuteAsync()
        {
            Method = "PUT";
            Path = V3ChangeSetsPath;

            return await base.ExecuteAsync();
        }

        public ChangeSets WithChannelId(int value)
        {
            AppendMultiValuedQueryParameter(Constants.ChannelIdKey, value);
            return this;
        }

        public ChangeSets WithBatchSize(int value)
        {
            AddQueryParameter(Constants.BatchSizeKey, value);
            return this;
        }
    }
}
