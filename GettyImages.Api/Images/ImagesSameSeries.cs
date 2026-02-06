using System.Net.Http;

using GettyImages.Api.Models;

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
            AddResponseFields(new[]
            {
                "accessrestriction", "allowed_use", "alternative_ids", "artist", "asset_family", "call_for_image", "caption",
                "collection_code", "collection_id", "collection_name", "color_type", "comp", "copyright", "date_camera_shot", "date_created",
                "date_submitted", "download_product", "download_sizes", "editorial_segments", "editorial_source", "entity_details",
                "event_ids", "graphical_style", "id", "istock_collection", "license_model", "max_dimensions", "orientation", "people",
                "preview", "product_types", "quality_rank", "referral_destinations", "thumb",
                "title", "uri_oembed"
            });
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

        public ImagesSameSeries IncludeKeywords()
        {
            AddResponseField("keywords");
            return this;
        }

        public ImagesSameSeries IncludeLargestDownloads()
        {
            AddResponseField("largest_downloads");
            return this;
        }
    }
}
