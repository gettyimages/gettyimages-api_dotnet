using System;

namespace GettyImages.Api.Entity
{
    [Flags]
    public enum Ethnicity
    {
        None = 0,
        [Description("black")] Black = 1,
        [Description("caucasian")] Caucasian = 2,
        [Description("east_asian")] EastAsian = 4,
        [Description("hispanic_latino")] HispanicLatino = 8,
        [Description("japanese")] Japanese = 16,
        [Description("middle_eastern")] MiddleEastern = 32,
        [Description("mixed_race_person")] MixedRacePerson = 64,
        [Description("multiethnic_group")] MultiethnicGroup = 128,
        [Description("native_american_first_nations")] NativeAmericanFirstNations = 256,
        [Description("pacific_islander")] PacificIslander = 512,
        [Description("south_asian")] SouthAsian = 1024,
        [Description("southeast_asian")] SoutheastAsian = 2048,
    }
}