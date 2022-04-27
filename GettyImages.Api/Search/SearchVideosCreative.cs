using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Models;
using ReleaseStatus = GettyImages.Api.Models.ReleaseStatus;
using SortOrder = GettyImages.Api.Models.SortOrder;

namespace GettyImages.Api.Search;

public class SearchVideosCreative : ApiRequest<SearchCreativeVideosResponse>
{
    protected const string V3SearchVideosPath = "/search/videos/creative";

    private SearchVideosCreative(Credentials credentials, string baseUrl, DelegatingHandler customHandler) :
        base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
    }

    internal static SearchVideosCreative GetInstance(Credentials credentials, string baseUrl,
        DelegatingHandler customHandler)
    {
        return new SearchVideosCreative(credentials, baseUrl, customHandler);
    }

    public override async Task<SearchCreativeVideosResponse> ExecuteAsync()
    {
        Method = "GET";
        Path = V3SearchVideosPath;

        return await base.ExecuteAsync();
    }

    public SearchVideosCreative WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }

    public SearchVideosCreative WithAgeOfPeople(AgeOfPeople value)
    {
        AddAgeOfPeopleFilter(value);
        return this;
    }

    public SearchVideosCreative WithCollectionCodes(IEnumerable<string> values)
    {
        AddCollectionCodes(values);
        return this;
    }

    public SearchVideosCreative WithCollectionFilterType(CollectionFilter value)
    {
        AddQueryParameter(Constants.CollectionFilterKey, value);
        return this;
    }

    public SearchVideosCreative WithDownloadProduct(ProductType value)
    {
        AddDownloadProduct(value);
        return this;
    }

    public SearchVideosCreative WithExcludeNudity(bool value = true)
    {
        AddQueryParameter(Constants.Excludenudity, value);
        return this;
    }

    public SearchVideosCreative WithResponseFields(IEnumerable<string> values)
    {
        AddResponseFields(values);
        return this;
    }

    public SearchVideosCreative WithAvailableFormat(string value)
    {
        AddQueryParameter(Constants.FormatAvailableKey, value);
        return this;
    }

    public SearchVideosCreative WithFrameRate(FrameRate value)
    {
        AddFrameRate(value);
        return this;
    }

    public SearchVideosCreative WithKeywordIds(IEnumerable<int> values)
    {
        AddKeywordIds(values);
        return this;
    }

    public virtual SearchVideosCreative WithLicenseModel(LicenseModel value)
    {
        AddLicenseModel(value);
        return this;
    }

    public SearchVideosCreative WithMinimumVideoClipLength(int value)
    {
        AddMinimumVideoClipLength(value);
        return this;
    }

    public SearchVideosCreative WithMaximumVideoClipLength(int value)
    {
        AddMaximumVideoClipLength(value);
        return this;
    }

    public SearchVideosCreative WithPage(int value)
    {
        AddQueryParameter(Constants.PageKey, value);
        return this;
    }

    public SearchVideosCreative WithPageSize(int value)
    {
        AddQueryParameter(Constants.PageSizeKey, value);
        return this;
    }

    public SearchVideosCreative WithPhrase(string value)
    {
        AddQueryParameter(Constants.PhraseKey, value);
        return this;
    }

    public SearchVideosCreative WithProductType(ProductType value)
    {
        AddProductTypes(value);
        return this;
    }

    public SearchVideosCreative WithSortOrder(SortOrder value)
    {
        AddQueryParameter(Constants.SortOrderKey, value);
        return this;
    }

    public SearchVideosCreative WithReleaseStatus(ReleaseStatus value)
    {
        AddQueryParameter(Constants.ReleaseStatus, value);
        return this;
    }

    public SearchVideosCreative WithIncludeFacets(bool value = true)
    {
        AddQueryParameter(Constants.IncludeFacetsKey, value);
        return this;
    }

    public SearchVideosCreative WithFacetFields(IEnumerable<string> values)
    {
        AddFacetResponseFields(values);
        return this;
    }

    public SearchVideosCreative WithFacetMaxCount(int value)
    {
        AddQueryParameter(Constants.FacetMaxCountKey, value);
        return this;
    }
}