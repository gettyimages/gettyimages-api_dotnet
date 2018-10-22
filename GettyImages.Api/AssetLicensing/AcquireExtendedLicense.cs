using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api.AssetLicensing
{
    public class AcquireExtendedLicense : ApiRequest
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

        public override async Task<dynamic> ExecuteAsync()
        {
            Method = "POST";
            Path = string.Format(V3AcquireExtendedLicensesPath, AssetId);
            
            return await base.ExecuteAsync();
        }

        public AcquireExtendedLicense WithId(string value)
        {
            AssetId = value;
            return this;
        }

        public AcquireExtendedLicense WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }
    }
}
