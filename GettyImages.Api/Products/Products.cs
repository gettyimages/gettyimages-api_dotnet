using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api.Products
{
    public class Products : ApiRequest
    {
        protected const string V3ProductsPath = "/products";

        private Products(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static Products GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new Products(credentials, baseUrl, customHandler);
        }

        public override async Task<dynamic> ExecuteAsync()
        {
            Method = "GET";
            Path = V3ProductsPath;

            return await base.ExecuteAsync();
        }

        public Products WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }

        public Products WithResponseFields(IEnumerable<string> values)
        {
            AddResponseFields(values);
            return this;
        }
    }
}
