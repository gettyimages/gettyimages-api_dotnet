using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api.Purchases
{
    public class PurchasedImages : ApiRequest
    {
        protected const string V3PurchasedImagesPath = "/purchased-images";

        private PurchasedImages(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static PurchasedImages GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new PurchasedImages(credentials, baseUrl, customHandler);
        }

        public override async Task<dynamic> ExecuteAsync()
        {
            Method = "GET";
            Path = V3PurchasedImagesPath;

            return await base.ExecuteAsync();
        }

        public PurchasedImages WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }

        public PurchasedImages WithEndDate(string value)
        {
            AddQueryParameter(Constants.EndDateKey, value);
            return this;
        }

        public PurchasedImages WithPage(int value)
        {
            AddQueryParameter(Constants.PageKey, value);
            return this;
        }

        public PurchasedImages WithPageSize(int value)
        {
            AddQueryParameter(Constants.PageSizeKey, value);
            return this;
        }

        public PurchasedImages WithStartDate(string value)
        {
            AddQueryParameter(Constants.StartDateKey, value);
            return this;
        }
    }
}
