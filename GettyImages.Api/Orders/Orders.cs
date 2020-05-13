using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api.Orders
{
    public class Orders : ApiRequest
    {
        protected const string V3OrdersPath = "/orders/";
        protected int id { get; set; }

        private Orders(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static Orders GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new Orders(credentials, baseUrl, customHandler);
        }

        public override async Task<dynamic> ExecuteAsync()
        {
            Method = "GET";
            Path = V3OrdersPath + id;

            return await base.ExecuteAsync();
        }

        public Orders WithId(int val)
        {
            id = val;
            return this;
        }

        public Orders WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }
    }
}
