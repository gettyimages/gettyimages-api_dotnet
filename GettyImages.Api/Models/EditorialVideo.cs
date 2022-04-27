using System;

namespace GettyImages.Api.Models;

[Flags]
public enum EditorialVideo
{
    None = 0,
    [Description("raw")] Raw = 1,
    [Description("produced")] Produced = 2
}