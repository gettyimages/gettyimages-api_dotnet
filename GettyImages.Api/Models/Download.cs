// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public class Download
{
    public string ProductId { get; set; }
    public string ProductType { get; set; }
    public string Uri { get; set; }
    public string AgreementName { get; set; }
}