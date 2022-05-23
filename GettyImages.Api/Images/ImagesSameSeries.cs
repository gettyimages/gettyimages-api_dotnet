using GettyImages.Api.Models;
using System.Net.Http;

namespace GettyImages.Api.Images
{
    public class ImagesSameSeries : ApiRequest<GetSimilarImagesResponse>
    {
        private ImagesSameSeries(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(
        customHandler)
        {
            Credentials = credentials;
            BaseUrl = baseUrl;
            Method = "GET";
        }

        internal static ImagesSameSeries GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
        {
            return new ImagesSameSeries(credentials, baseUrl, customHandler);
        }

        public ImagesSameSeries WithId(string value)
        {
            Path = $"/images/{value}/same-series";
            return this;
        }

        public ImagesSameSeries WithAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
            return this;
        }

        public ImagesSameSeries WithPage(int value)
        {
            AddQueryParameter(Constants.PageKey, value);
            return this;
        }

        public ImagesSameSeries WithPageSize(int value)
        {
            AddQueryParameter(Constants.PageSizeKey, value);
            return this;
        }
    }
}
