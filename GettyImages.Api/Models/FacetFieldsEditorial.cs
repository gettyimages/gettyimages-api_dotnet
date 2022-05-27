
using System;

namespace GettyImages.Api.Models
{
    [Flags]
    public enum FacetFieldsEditorial
    {
        None = 0,
        [Description("artists")] Artists = 1,
        [Description("events")] Events = 2,
        [Description("locations")] Locations = 4,
        [Description("specific_people")] SpecificPeople = 8
    }
}
