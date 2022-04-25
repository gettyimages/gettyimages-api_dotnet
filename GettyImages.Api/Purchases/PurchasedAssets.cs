using System;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Models;

namespace GettyImages.Api.Purchases
{
    public class PurchasedAssets : ApiRequest<GetPreviouslyPurchasedAssetsResponse>
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

        public override async Task<GetPreviouslyPurchasedAssetsResponse> ExecuteAsync()
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

        public PurchasedAssets WithEndDate(DateTime value)
        {
            AddQueryParameter(Constants.DateToKey, value);
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

        public PurchasedAssets WithStartDate(DateTime value)
        {
            AddQueryParameter(Constants.DateFromKey, value);
            return this;
        }

        public PurchasedAssets WithCompanyPurchases(bool value = true)
        {
            AddQueryParameter(Constants.CompanyPurchasesKey, value);
            return this;
        }
    }
}
