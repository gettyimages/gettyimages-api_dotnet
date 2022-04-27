using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GettyImages.Api.Models;

namespace GettyImages.Api;

public class ApiRequest<T> : ApiRequest
{
    protected ApiRequest(DelegatingHandler customHandler) : base(customHandler)
    {
    }

    public new virtual async Task<T> ExecuteAsync()
    {
        var helper = new WebHelper(Credentials, BaseUrl, _customHandler);
        switch (Method)
        {
            case "GET":
                return await helper.GetAsync<T>(BuildQuery(QueryParameters), Path, BuildHeaders(HeaderParameters));
            case "POST":
                return await helper.PostQueryAsync<T>(BuildQuery(QueryParameters), Path, BuildHeaders(HeaderParameters),
                    BuildBody());
            case "PUT":
                return await helper.PutQueryAsync<T>(BuildQuery(QueryParameters), Path, BuildHeaders(HeaderParameters),
                    BuildBody());
            case "DELETE":
                return await helper.DeleteQueryAsync<T>(BuildQuery(QueryParameters), Path,
                    BuildHeaders(HeaderParameters));
            default:
                throw new SdkException("No appropriate HTTP method found for this request.");
        }
    }
}

public class ApiRequest
{
    private const string SpaceString = " ";
    protected readonly DelegatingHandler _customHandler;
    protected internal readonly IDictionary<string, object> HeaderParameters;
    protected readonly IDictionary<string, object> QueryParameters;
    protected string BaseUrl;
    protected internal object BodyParameter;
    protected Credentials Credentials;
    protected string Method;
    protected string Path;
    protected internal string StringBodyParameter;

    protected ApiRequest(DelegatingHandler customHandler)
    {
        _customHandler = customHandler;
        QueryParameters = new Dictionary<string, object>();
        HeaderParameters = new Dictionary<string, object>();
    }

    public virtual async Task<dynamic> ExecuteAsync()
    {
        var helper = new WebHelper(Credentials, BaseUrl, _customHandler);
        switch (Method)
        {
            case "GET":
                return await helper.GetAsync(BuildQuery(QueryParameters), Path, BuildHeaders(HeaderParameters));
            case "POST":
                return await helper.PostQueryAsync(BuildQuery(QueryParameters), Path, BuildHeaders(HeaderParameters),
                    BuildBody());
            case "PUT":
                return await helper.PutQueryAsync(BuildQuery(QueryParameters), Path, BuildHeaders(HeaderParameters),
                    BuildBody());
            case "DELETE":
                return await helper.DeleteQueryAsync(BuildQuery(QueryParameters), Path, BuildHeaders(HeaderParameters));
            default:
                throw new SdkException("No appropriate HTTP method found for this request.");
        }
    }

    public virtual async Task ExecuteVoidAsync()
    {
        var helper = new WebHelper(Credentials, BaseUrl, _customHandler);
        switch (Method)
        {
            case "GET":
                await helper.GetAsync(BuildQuery(QueryParameters), Path, BuildHeaders(HeaderParameters));
                break;
            case "POST":
                await helper.PostQueryAsync(BuildQuery(QueryParameters), Path, BuildHeaders(HeaderParameters),
                    BuildBody());
                break;
            case "PUT":
                await helper.PutQueryVoidAsync(BuildQuery(QueryParameters), Path, BuildHeaders(HeaderParameters),
                    BuildBody());
                break;
            case "DELETE":
                await helper.DeleteQueryVoidAsync(BuildQuery(QueryParameters), Path, BuildHeaders(HeaderParameters));
                break;
            default:
                throw new SdkException("No appropriate HTTP method found for this request.");
        }
    }

    protected static IEnumerable<KeyValuePair<string, string>> BuildQuery(
        IEnumerable<KeyValuePair<string, object>> queryParameters)
    {
        var keyValuePairs = queryParameters as KeyValuePair<string, object>[] ??
                            queryParameters.ToArray();

        return keyValuePairs.Where(v => v.Value is string || v.Value is bool || v.Value is int || v.Value is DateTime)
            .Select(
                d =>
                    new KeyValuePair<string, string>(d.Key,
                        d.Value.ToString()))
            .Union(keyValuePairs
                .Where(v => v.Value is Enum)
                .Select(
                    d =>
                        new KeyValuePair<string, string>(d.Key,
                            BuildEnumString((Enum)d.Value))))
            .Union(keyValuePairs
                .Where(v => v.Value is IEnumerable<string>)
                .Select(
                    d => new KeyValuePair<string, string>(d.Key, string.Join(",", (IEnumerable<string>)d.Value))))
            .Union(keyValuePairs
                .Where(v => v.Value is IEnumerable<int>)
                .Select(
                    d => new KeyValuePair<string, string>(d.Key, string.Join(",", (IEnumerable<int>)d.Value))))
            .AsEnumerable();
    }

    protected static IEnumerable<KeyValuePair<string, string>> BuildHeaders(
        IEnumerable<KeyValuePair<string, object>> headerParameters)
    {
        if (!headerParameters.Any())
        {
            return null;
        }

        var keyValuePairs = headerParameters as KeyValuePair<string, object>[] ??
                            headerParameters.ToArray();

        return keyValuePairs.Where(v => v.Value is string)
            .Select(
                d =>
                    new KeyValuePair<string, string>(d.Key,
                        d.Value.ToString()))
            .Union(keyValuePairs
                .Where(v => v.Value is Enum)
                .Select(
                    d =>
                        new KeyValuePair<string, string>(d.Key,
                            BuildEnumString((Enum)d.Value))))
            .Union(keyValuePairs
                .Where(v => v.Value is IEnumerable<string>)
                .Select(
                    d => new KeyValuePair<string, string>(d.Key, string.Join(",", (IEnumerable<string>)d.Value))))
            .AsEnumerable();
    }

    protected HttpContent BuildBody()
    {
        if (!string.IsNullOrEmpty(StringBodyParameter))
        {
            var bytes = Encoding.UTF8.GetBytes(StringBodyParameter);
            var content = new ByteArrayContent(bytes);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return content;
        }

        if (BodyParameter != null)
        {
            var serializedPayload = Serializer.Serialize(BodyParameter);
            var bytes = Encoding.UTF8.GetBytes(serializedPayload);
            var content = new ByteArrayContent(bytes);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return content;
        }

        return null;
    }

    private static string BuildEnumString(Enum value)
    {
        return
            value.GetType().GetTypeInfo().CustomAttributes.Where(a => a.AttributeType == typeof(FlagsAttribute))
                .Count() !=
            0
                ? string.Join(",", GetFlags(value).Select(GetEnumDescription).ToArray())
                : GetEnumDescription(value).ToLowerInvariant().Replace(SpaceString, string.Empty);
    }

    private static string GetEnumDescription(Enum value)
    {
        var fi = value.GetType().GetRuntimeFields().FirstOrDefault(f => f.Name == value.ToString());
        if (fi != null)
        {
            var attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
        }

        return value.ToString().ToLowerInvariant();
    }

    private static IEnumerable<Enum> GetFlags(Enum input)
    {
        return Enum.GetValues(input.GetType()).Cast<Enum>().Where(input.HasFlag).Where(v => Convert.ToInt64(v) != 0);
    }

    protected void AddQueryParameter(string key, object value)
    {
        if (!key.Equals("ids") && !key.Equals("image_fingerprint") && value is string)
        {
            value = value.ToString().ToLowerInvariant();
        }

        if (QueryParameters.ContainsKey(key))
        {
            QueryParameters[key] = value;
        }
        else
        {
            QueryParameters.Add(key, value);
        }
    }

    protected void AppendMultiValuedQueryParameter(string key, object value)
    {
        if (!QueryParameters.ContainsKey(key))
        {
            QueryParameters.Add(key, new List<string> { value.ToString() });
        }
        else
        {
            var values = (List<string>)QueryParameters[key];
            if (!values.Contains(value.ToString()))
            {
                values.Add(value.ToString());
            }
        }
    }

    protected void AddHeaderParameter(string key, object value)
    {
        if (HeaderParameters.ContainsKey(key))
        {
            HeaderParameters[key] = value;
        }
        else
        {
            HeaderParameters.Add(key, value);
        }
    }

    protected void AddAgeOfPeopleFilter(AgeOfPeople value)
    {
        if (QueryParameters.ContainsKey(Constants.AgeOfPeopleKey))
        {
            QueryParameters[Constants.AgeOfPeopleKey] = value == AgeOfPeople.None
                ? value
                : (AgeOfPeople)QueryParameters[Constants.AgeOfPeopleKey] | value;
        }
        else
        {
            QueryParameters.Add(Constants.AgeOfPeopleKey, value);
        }
    }

    protected void AddAssetIds(IEnumerable<string> values)
    {
        if (!QueryParameters.ContainsKey(Constants.AssetIdsKey))
        {
            QueryParameters.Add(Constants.AssetIdsKey, values);
        }
        else
        {
            var assets = QueryParameters[Constants.AssetIdsKey] as IEnumerable<string>;
            assets = assets.Union(values).Distinct();
            QueryParameters[Constants.AssetIdsKey] = assets.ToList();
        }
    }

    protected void AddArtists(IEnumerable<string> values)
    {
        if (!QueryParameters.ContainsKey(Constants.ArtistKey))
        {
            QueryParameters.Add(Constants.ArtistKey, values);
        }
        else
        {
            var assets = QueryParameters[Constants.ArtistKey] as IEnumerable<string>;
            assets = assets.Union(values).Distinct();
            QueryParameters[Constants.ArtistKey] = assets.ToList();
        }
    }

    protected void AddCollectionCodes(IEnumerable<string> values)
    {
        if (!QueryParameters.ContainsKey(Constants.CollectionCodeKey))
        {
            QueryParameters.Add(Constants.CollectionCodeKey, values);
        }
        else
        {
            var assets = QueryParameters[Constants.CollectionCodeKey] as IEnumerable<string>;
            assets = assets.Union(values).Distinct();
            QueryParameters[Constants.CollectionCodeKey] = assets.ToList();
        }
    }

    protected void AddComposition(Composition value)
    {
        if (QueryParameters.ContainsKey(Constants.CompositionKey))
        {
            QueryParameters[Constants.CompositionKey] = value == Composition.None
                ? value
                : (Composition)QueryParameters[Constants.CompositionKey] | value;
        }
        else
        {
            QueryParameters.Add(Constants.CompositionKey, value);
        }
    }

    protected void AddDownloadProduct(ProductType value)
    {
        if (QueryParameters.ContainsKey(Constants.DownloadProductKey))
        {
            QueryParameters[Constants.DownloadProductKey] = value;
        }
        else
        {
            QueryParameters.Add(Constants.DownloadProductKey, value);
        }
    }

    protected void AddEditorialSegment(EditorialSegment value)
    {
        if (QueryParameters.ContainsKey(Constants.EditorialSegmentsKey))
        {
            QueryParameters[Constants.EditorialSegmentsKey] = value == EditorialSegment.None
                ? value
                : (EditorialSegment)QueryParameters[Constants.EditorialSegmentsKey] | value;
        }
        else
        {
            QueryParameters.Add(Constants.EditorialSegmentsKey, value);
        }
    }

    protected void AddEditorialVideoType(EditorialVideo value)
    {
        if (QueryParameters.ContainsKey(Constants.EditorialVideoKey))
        {
            QueryParameters[Constants.EditorialVideoKey] = value == EditorialVideo.None
                ? value
                : (EditorialVideo)QueryParameters[Constants.EditorialVideoKey] | value;
        }
        else
        {
            QueryParameters.Add(Constants.EditorialVideoKey, value);
        }
    }

    protected void AddEntityUris(IEnumerable<string> values)
    {
        if (!QueryParameters.ContainsKey(Constants.EntityUriKey))
        {
            QueryParameters.Add(Constants.EntityUriKey, values);
        }
        else
        {
            var assets = QueryParameters[Constants.EntityUriKey] as IEnumerable<string>;
            assets = assets.Union(values).Distinct();
            QueryParameters[Constants.EntityUriKey] = assets.ToList();
        }
    }

    protected void AddEthnicity(Ethnicity value)
    {
        if (QueryParameters.ContainsKey(Constants.EthnicityKey))
        {
            QueryParameters[Constants.EthnicityKey] = value == Ethnicity.None
                ? value
                : (Ethnicity)QueryParameters[Constants.EthnicityKey] | value;
        }
        else
        {
            QueryParameters.Add(Constants.EthnicityKey, value);
        }
    }

    protected void AddEventIds(IEnumerable<int> values)
    {
        if (!QueryParameters.ContainsKey(Constants.EventIdsKey))
        {
            QueryParameters.Add(Constants.EventIdsKey, values);
        }
        else
        {
            var assets = QueryParameters[Constants.EventIdsKey] as IEnumerable<int>;
            assets = assets.Union(values).Distinct();
            QueryParameters[Constants.EventIdsKey] = assets.ToList();
        }
    }

    protected void AddResponseFields(IEnumerable<string> values)
    {
        if (!QueryParameters.ContainsKey(Constants.FieldsKey))
        {
            QueryParameters.Add(Constants.FieldsKey, values);
        }
        else
        {
            var assets = QueryParameters[Constants.FieldsKey] as IEnumerable<string>;
            assets = assets.Union(values).Distinct();
            QueryParameters[Constants.FieldsKey] = assets.ToList();
        }
    }

    protected void AddFileTypes(FileType value)
    {
        if (QueryParameters.ContainsKey(Constants.FileTypesKey))
        {
            QueryParameters[Constants.FileTypesKey] = value == FileType.None
                ? value
                : (FileType)QueryParameters[Constants.FileTypesKey] | value;
        }
        else
        {
            QueryParameters.Add(Constants.FileTypesKey, value);
        }
    }

    protected void AddFrameRate(FrameRate value)
    {
        if (QueryParameters.ContainsKey(Constants.FrameRatesKey))
        {
            QueryParameters[Constants.FrameRatesKey] = value == FrameRate.None
                ? value
                : (FrameRate)QueryParameters[Constants.FrameRatesKey] | value;
        }
        else
        {
            QueryParameters.Add(Constants.FrameRatesKey, value);
        }
    }

    protected void AddGraphicalStyle(GraphicalStyles value)
    {
        if (QueryParameters.ContainsKey(Constants.GraphicalStylesKey))
        {
            QueryParameters[Constants.GraphicalStylesKey] = value == GraphicalStyles.None
                ? value
                : (GraphicalStyles)QueryParameters[Constants.GraphicalStylesKey] | value;
        }
        else
        {
            QueryParameters.Add(Constants.GraphicalStylesKey, value);
        }
    }

    protected void AddKeywordIds(IEnumerable<int> values)
    {
        if (!QueryParameters.ContainsKey(Constants.KeywordIdsKey))
        {
            QueryParameters.Add(Constants.KeywordIdsKey, values);
        }
        else
        {
            var keywords = QueryParameters[Constants.KeywordIdsKey] as IEnumerable<int>;
            keywords = keywords.Union(values).Distinct();
            QueryParameters[Constants.KeywordIdsKey] = keywords.ToList();
        }
    }

    protected void AddExcludeKeywordIds(IEnumerable<int> values)
    {
        if (!QueryParameters.ContainsKey(Constants.ExcludeKeywordIdsKey))
        {
            QueryParameters.Add(Constants.ExcludeKeywordIdsKey, values);
        }
        else
        {
            var keywords = QueryParameters[Constants.ExcludeKeywordIdsKey] as IEnumerable<int>;
            keywords = keywords.Union(values).Distinct();
            QueryParameters[Constants.ExcludeKeywordIdsKey] = keywords.ToList();
        }
    }

    protected void AddLicenseModel(LicenseModel value)
    {
        if (QueryParameters.ContainsKey(Constants.LicenseModelsKey))
        {
            QueryParameters[Constants.LicenseModelsKey] = value == LicenseModel.None
                ? value
                : (LicenseModel)QueryParameters[Constants.LicenseModelsKey] | value;
        }
        else
        {
            QueryParameters.Add(Constants.LicenseModelsKey, value);
        }
    }

    protected void AddMinimumVideoClipLength(int value)
    {
        if (QueryParameters.ContainsKey(Constants.MinimumVideoClipLengthKey))
        {
            QueryParameters[Constants.MinimumVideoClipLengthKey] = value;
        }
        else
        {
            QueryParameters.Add(Constants.MinimumVideoClipLengthKey, value);
        }
    }

    protected void AddMaximumVideoClipLength(int value)
    {
        if (QueryParameters.ContainsKey(Constants.MaximumVideoClipLengthKey))
        {
            QueryParameters[Constants.MaximumVideoClipLengthKey] = value;
        }
        else
        {
            QueryParameters.Add(Constants.MaximumVideoClipLengthKey, value);
        }
    }

    protected void AddNumberOfPeople(NumberOfPeople value)
    {
        if (QueryParameters.ContainsKey(Constants.NumberOfPeopleKey))
        {
            QueryParameters[Constants.NumberOfPeopleKey] = value == NumberOfPeople.None
                ? value
                : (NumberOfPeople)QueryParameters[Constants.NumberOfPeopleKey] | value;
        }
        else
        {
            QueryParameters.Add(Constants.NumberOfPeopleKey, value);
        }
    }

    protected void AddOrientation(Orientation value)
    {
        if (QueryParameters.ContainsKey(Constants.OrientationsKey))
        {
            QueryParameters[Constants.OrientationsKey] = value == Orientation.None
                ? value
                : (Orientation)QueryParameters[Constants.OrientationsKey] | value;
        }
        else
        {
            QueryParameters.Add(Constants.OrientationsKey, value);
        }
    }

    protected void AddProductTypes(ProductType value)
    {
        if (QueryParameters.ContainsKey(Constants.ProductTypesKey))
        {
            QueryParameters[Constants.ProductTypesKey] = value == ProductType.None
                ? value
                : (ProductType)QueryParameters[Constants.ProductTypesKey] | value;
        }
        else
        {
            QueryParameters.Add(Constants.ProductTypesKey, value);
        }
    }

    protected void AddSpecificPeople(IEnumerable<string> values)
    {
        if (!QueryParameters.ContainsKey(Constants.SpecificPeopleKey))
        {
            QueryParameters.Add(Constants.SpecificPeopleKey, values);
        }
        else
        {
            var assets = QueryParameters[Constants.SpecificPeopleKey] as IEnumerable<string>;
            assets = assets.Union(values).Distinct();
            QueryParameters[Constants.SpecificPeopleKey] = assets.ToList();
        }
    }

    protected void AddFacetResponseFields(IEnumerable<string> values)
    {
        if (!QueryParameters.ContainsKey(Constants.FacetFieldsKey))
        {
            QueryParameters.Add(Constants.FacetFieldsKey, values);
        }
        else
        {
            var assets = QueryParameters[Constants.FacetFieldsKey] as IEnumerable<string>;
            assets = assets.Union(values).Distinct();
            QueryParameters[Constants.FacetFieldsKey] = assets.ToList();
        }
    }
}