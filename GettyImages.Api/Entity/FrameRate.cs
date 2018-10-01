using System;

namespace GettyImages.Api.Entity
{
    [Flags]

    public enum FrameRate
    {
        None = 0,
        [Description("23.98")] FrameRate23 = 1,
        [Description("24")] FrameRate24 = 2,
        [Description("25")] FrameRate25 = 4,
        [Description("29.97")] FrameRate29 = 8,
        [Description("30")] FrameRate30 = 16,
        [Description("50")] FrameRate50 = 32,
        [Description("59.94")] FrameRate59 = 64,
        [Description("60")] FrameRate60 = 128,
    }
}
