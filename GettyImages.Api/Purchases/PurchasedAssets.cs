using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api.Purchases
{
    public class PurchasedAssets : ApiRequest
    {
        protected const string V3PurchasedAssetsPath = "/purchased-assets";

        private PurchasedAssets(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static PurchasedAssets GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new PurchasedAssets(credentials, baseUrl, customHandler);
        }

        public override async Task<dynamic> ExecuteAsync()
        {
            Method = "GET";
            Path = V3PurchasedAssetsPath;

            return await base.ExecuteAsync();
        }

        public PurchasedAssets WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }

        public PurchasedAssets WithEndDate(string value)
        {
            AddQueryParameter(Constants.EndDateKey, value);
            return this;
        }

        public PurchasedAssets WithPage(int value)
        {
            AddQueryParameter(Constants.PageKey, value);
            return this;
        }

        public PurchasedAssets WithPageSize(int value)
        {
            AddQueryParameter(Constants.PageSizeKey, value);
            return this;
        }

        public PurchasedAssets WithStartDate(string value)
        {
            AddQueryParameter(Constants.StartDateKey, value);
            return this;
        }
    }
}
