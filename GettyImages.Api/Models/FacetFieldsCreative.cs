
using System;

namespace GettyImages.Api.Models
{
    [Flags]
    public enum FacetFieldsCreative
    {
        None = 0,
        [Description("artists")] Artists = 1,
        [Description("locations")] Locations = 2
    }
}
