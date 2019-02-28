using System.Net.Http;
using System.Threading.Tasks;

namespace GettyImages.Api.Customers
{
    public class Customers : ApiRequest
    {
        protected const string V3CustomersPath = "/customers/current";

        public Customers(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
        }

        internal static Customers GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new Customers(credentials, baseUrl, customHandler);
        }

        public override async Task<dynamic> ExecuteAsync()
        {
            Method = "GET";
            Path = V3CustomersPath;

            return await base.ExecuteAsync();
        }

        public Customers WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);

            return this;
        }
    }
}
