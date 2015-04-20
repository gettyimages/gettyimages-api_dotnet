using System;

namespace GettyImages.Connect.Search
{
    [Flags]
    public enum FileType
    {
        none = 0,
        eps = 2,
        gif = 4,
        jpg = 8,
        png = 16
    }
}
