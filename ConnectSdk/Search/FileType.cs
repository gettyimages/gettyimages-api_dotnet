using System;

namespace GettyImages.Connect.Search
{
    [Flags]
    public enum FileType
    {
        None = 0,
        eps = 1,
        gif = 2,
        jpg = 4,
        png = 8
    }
}
