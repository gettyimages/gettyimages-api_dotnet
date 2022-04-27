using System;

namespace GettyImages.Api.Models;

[Flags]
public enum Composition
{
    None = 0,
    [Description("abstract")] Abstract = 1,
    [Description("candid")] Candid = 2,
    [Description("close_up")] CloseUp = 4,
    [Description("copy_space")] CopySpace = 8,
    [Description("cut_out")] CutOut = 16,
    [Description("full_frame")] FullFrame = 32,
    [Description("full_length")] FullLength = 64,
    [Description("headshot")] Headshot = 128,
    [Description("looking_at_camera")] LookingAtCamera = 256,
    [Description("macro")] Macro = 512,
    [Description("portrait")] Portrait = 1024,
    [Description("sparse")] Sparse = 2048,
    [Description("still_life")] StillLife = 4096,
    [Description("three_quarter_length")] ThreeQuarterLength = 8128,
    [Description("waist_up")] WaistUp = 16384
}