using System;

namespace GettyImages.Connect.Search
{
    [Flags]
    public enum Composition
    {
        None = 0,
        [Description("abstract")] Abstract = 1,
        [Description("candid")] Candid = 2,
        [Description("close_up")] Close_Up = 4,
        [Description("copy_space")] Copy_Space = 8,
        [Description("cut_out")] Cut_Out = 16,
        [Description("full_frame")] Full_Frame = 32,
        [Description("full_length")] Full_Length = 64,
        [Description("headshot")] Headshot = 128,
        [Description("looking_at_camera")] Looking_At_Camera = 256,
        [Description("macro")] Macro = 512,
        [Description("portrait")] Portrait = 1024,
        [Description("sparse")] Sparse = 2048,
        [Description("still_life")] Still_Life = 4096,
        [Description("three_quarter_length")] Three_Quarter_Length = 8128,
        [Description("waist_up")] Waist_Up = 16384
    }
}
