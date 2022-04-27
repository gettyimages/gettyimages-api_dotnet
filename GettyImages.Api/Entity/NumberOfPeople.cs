using System;

namespace GettyImages.Api.Entity;

[Flags]
public enum NumberOfPeople
{
    [Description("none")] None = 0,
    [Description("one")] One = 2,
    [Description("two")] Two = 4,
    [Description("group")] Group = 8
}