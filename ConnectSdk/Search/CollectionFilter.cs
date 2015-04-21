using System;

namespace GettyImages.Connect.Search
{
    [Flags]
    public enum CollectionFilter
    {
        None = 0,
        [Description("include")] Include = 1,
        [Description("exclude")] Exclude = 2
    }
}
