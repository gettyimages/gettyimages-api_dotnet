using System;

namespace GettyImages.Api.Entity;

[Flags]
public enum GraphicalStyles
{
    None = 0,
    [Description("fine_art")] FineArt = 1,
    [Description("photography")] Photography = 2,
    [Description("illustration")] Illustration = 4,
    [Description("vector")] Vector = 8
}