// ReSharper disable UnusedMember.Global
using System;

namespace GettyImages.Api.Models;

[Flags]
public enum AspectRatio : long
{
    None = 0,
    [Description("16:9")] AspectRatio16_9 = 1,
    [Description("9:16")] AspectRatio9_16 = 2,
    [Description("3:4")] AspectRatio3_4 = 4,
    [Description("4:3")] AspectRatio4_3 = 8,
    [Description("4:5")] AspectRatio4_5 = 16,
    [Description("2:1")] AspectRatio2_1 = 32,
    [Description("17:9")] AspectRatio17_9 = 64,
    [Description("9:17")] AspectRatio9_17 = 128
}