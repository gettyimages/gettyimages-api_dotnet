using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Models;

namespace GettyImages.Api.Usage;

public class UsageBatches : ApiRequest<ReportUsageBatchResponse>
{
    protected const string V3UsageBatchesPath = "/usage-batches";

    private UsageBatches(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
    }

    protected string AssetId { get; set; }

    internal static UsageBatches GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new UsageBatches(credentials, baseUrl, customHandler);
    }

    public override async Task<ReportUsageBatchResponse> ExecuteAsync()
    {
        Method = "PUT";
        Path = V3UsageBatchesPath + "/" + AssetId;

        return await base.ExecuteAsync();
    }

    public UsageBatches WithId(string value)
    {
        AssetId = value;
        return this;
    }

    public UsageBatches WithRequest(ReportUsageBatchRequest value)
    {
        BodyParameter = value;
        return this;
    }
}