namespace GettyImages.Api.Models;

public enum MinimumSize
{
    None = 0,
    [Description("x_small")] Xsmall,
    [Description("small")] Small,
    [Description("medium")] Medium,
    [Description("large")] Large,
    [Description("x_large")] Xlarge,
    [Description("xx_large")] Xxlarge,
    [Description("vector")] Vector
}
