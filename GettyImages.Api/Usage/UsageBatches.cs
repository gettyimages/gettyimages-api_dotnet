using System.Net.Http;
using GettyImages.Api.Models;

namespace GettyImages.Api.Usage;

public class UsageBatches : ApiRequest<ReportUsageBatchResponse>
{
    private UsageBatches(Credentials credentials, string baseUrl, DelegatingHandler customHandler) : base(customHandler)
    {
        Credentials = credentials;
        BaseUrl = baseUrl;
        Method = "PUT";
    }
    
    internal static UsageBatches GetInstance(Credentials credentials, string baseUrl, DelegatingHandler customHandler)
    {
        return new UsageBatches(credentials, baseUrl, customHandler);
    }

    public UsageBatches WithId(string value)
    {
        Path = $"/usage-batches/{value}";
        return this;
    }

    public UsageBatches WithRequest(ReportUsageBatchRequest value)
    {
        BodyParameter = value;
        return this;
    }
}