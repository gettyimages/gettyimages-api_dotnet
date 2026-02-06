using System;

namespace GettyImages.Api.Models;

[Flags]
public enum FileType
{
    None = 0,
    [Description("eps")] Eps = 1,
    [Description("jpg")] Jpg = 2
}
