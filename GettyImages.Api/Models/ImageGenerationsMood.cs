using System.Text.Json.Serialization;

namespace GettyImages.Api.Models;

public enum ImageGenerationsMood
{
    None = 0,
    [Description("black_and_white")] BlackAndWhite,
    [Description("warm")] Warm,
    [Description("cool")] Cool,
    [Description("natural")] Natural,
    [Description("vivid")] Vivid,
    [Description("dramatic")] Dramatic,
    [Description("bold")] Bold
}
