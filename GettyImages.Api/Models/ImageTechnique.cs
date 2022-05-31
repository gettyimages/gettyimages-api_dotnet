using System;

namespace GettyImages.Api.Models
{

    [Flags]
    public enum ImageTechnique : long
    {
        None = 0,
        [Description("realtime")] Realtime = 1,
        [Description("time_lapse")] TimeLapse = 2,
        [Description("slow_motion")] SlowMotion = 4,
        [Description("color")] Color = 8,
        [Description("black_and_white")] BlackAndWhite = 16,
        [Description("animation")] Animation = 32,
        [Description("selective_focus")] SelectiveFocus = 64
    }
}
