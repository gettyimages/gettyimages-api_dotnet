// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public class Keyword
{
    public string KeywordId { get; set; }
    public string Text { get; set; }
    public string Type { get; set; }
    public int? Relevance { get; set; }
    public string[] EntityUris { get; set; }
    public string[] EntityTypes { get; set; }
}
