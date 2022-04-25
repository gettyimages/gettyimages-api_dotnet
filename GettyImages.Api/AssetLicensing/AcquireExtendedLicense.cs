using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Models;

namespace GettyImages.Api.AssetLicensing
{
    public class AcquireExtendedLicense : ApiRequest<AssetLicensingResponse>
    {
        protected const string V3AcquireExtendedLicensesPath = "/asset-licensing/{0}";
        protected string AssetId { get; set; }

        private AcquireExtendedLicense(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static AcquireExtendedLicense GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new AcquireExtendedLicense(credentials, baseUrl, customHandler);
        }

        public override async Task<AssetLicensingResponse> ExecuteAsync()
        {
            Method = "POST";
            Path = string.Format(V3AcquireExtendedLicensesPath, AssetId);
            
            return await base.ExecuteAsync();
        }

        public AcquireExtendedLicense WithAssetId(string value)
        {
            AssetId = value;
            return this;
        }

        public AcquireExtendedLicense WithExtendedLicenses(AcquireAssetLicensesRequest value)
        {
            BodyParameter = value;
            return this;
        }

        public AcquireExtendedLicense WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }
    }
}
