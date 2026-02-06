using System.Net.Http;

using GettyImages.Api.Models;

namespace GettyImages.Api.AssetLicensing;

public class AcquireExtendedLicense : ApiRequest<AssetLicensingResponse>
{
    private AcquireExtendedLicense(Credentials credentials, string baseUrl, DelegatingHandler customHandler) :
        base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "POST";
    }

    protected string AssetId { get; set; }

    internal static AcquireExtendedLicense GetInstance(Credentials credentials, string baseUrl,
        DelegatingHandler customHandler)
    {
        return new AcquireExtendedLicense(credentials, baseUrl, customHandler);
    }

    public AcquireExtendedLicense WithAssetId(string value)
    {
        Path = $"/asset-licensing/{value}";
        return this;
    }

    public AcquireExtendedLicense WithExtendedLicenses(AcquireAssetLicensesRequest value)
    {
        BodyParameter = value;
        return this;
    }

    public AcquireExtendedLicense WithAcceptLanguage(string value)
    {
        AddHeaderParameter(Constants.AcceptLanguage, value);
        return this;
    }
}
