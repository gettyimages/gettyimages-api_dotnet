using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api.AssetChanges
{
    public class DeleteAssetChanges : ApiRequest
    {
        protected const string V3DeleteAssetChangesPath = "/asset-changes/change-sets";
        protected long ChangeSetId { get; set; }

        private DeleteAssetChanges(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static DeleteAssetChanges GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new DeleteAssetChanges(credentials, baseUrl, customHandler);
        }

        public override async Task<dynamic> ExecuteAsync()
        {
            Method = "DELETE";
            Path = V3DeleteAssetChangesPath + "/" + ChangeSetId;

            return await base.ExecuteAsync();
        }

        public DeleteAssetChanges WithChangeSetId(long value)
        {
            ChangeSetId = value;
            return this;
        }
    }
}
