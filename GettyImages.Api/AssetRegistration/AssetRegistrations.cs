using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api.AssetRegistration
{
    public class AssetRegistrations : ApiRequest
    {
        protected const string V3AssetRegistrationsPath = "/asset-registrations";

        private AssetRegistrations(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static AssetRegistrations GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new AssetRegistrations(credentials, baseUrl, customHandler);
        }

        public override async Task<dynamic> ExecuteAsync()
        {
            Method = "POST";
            Path = V3AssetRegistrationsPath;

            return await base.ExecuteAsync();
        }

        public AssetRegistrations WithRequest(string value)
        {
            BodyParameter = value;
            return this;
        }
    }
}
