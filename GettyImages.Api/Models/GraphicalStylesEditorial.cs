using System;

namespace GettyImages.Api.Models;

[Flags]
public enum GraphicalStylesEditorial
{
    None = 0,
    [Description("photography")] Photography = 1,
    [Description("illustration")] Illustration = 2,
    [Description("vector")] Vector = 4
}