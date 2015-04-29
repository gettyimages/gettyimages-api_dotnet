using System;

namespace GettyImages.Api.Search.Entity
{
    [Flags]
    public enum GraphicalStyles
    {
        None = 0,
        [Description("Fine_Art")] FineArt = 1,
        [Description("Photography")] Photography = 2,
        [Description("Illustration")] Illustration = 4
    }
}