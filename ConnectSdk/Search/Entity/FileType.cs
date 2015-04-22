using System;

namespace GettyImages.Connect.Search.Entity
{
    [Flags]
    public enum FileType
    {
        None = 0,
        [Description("eps")] Eps = 1,
        [Description("gif")] Gif = 2,
        [Description("jpg")] Jpg = 4,
        [Description("png")] Png = 8
    }
}
