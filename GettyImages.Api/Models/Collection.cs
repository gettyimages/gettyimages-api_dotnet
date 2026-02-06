// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public class Collection
{
    public string AssetFamily { get; set; }
    public string Code { get; set; }
    public int Id { get; set; }
    public string LicenseModel { get; set; }
    public string Name { get; set; }
    public string[] ProductTypes { get; set; }
}
