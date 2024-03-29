﻿// ReSharper disable UnusedMember.Global
using System;

namespace GettyImages.Api.Models;

[Flags]
public enum AgeOfPeople : long
{
    None = 0,
    [Description("newborn")] Newborn = 1,
    [Description("baby")] Baby = 2,
    [Description("child")] Child = 4,
    [Description("teenager")] Teenager = 8,
    [Description("young_adult")] YoungAdult = 16,
    [Description("adult")] Adult = 32,
    [Description("adults_only")] AdultsOnly = 64,
    [Description("mature_adult")] MatureAdult = 128,
    [Description("senior_adult")] SeniorAdult = 256,
    [Description("0-1_months")] Months0To1 = 512,
    [Description("2-5_months")] Months2To5 = 1024,
    [Description("6-11_months")] Months6To11 = 2048,
    [Description("12-17_months")] Months12To17 = 4096,
    [Description("18-23_months")] Months18To23 = 8192,
    [Description("2-3_years")] Years2To3 = 16384,
    [Description("4-5_years")] Years4To5 = 32768,
    [Description("6-7_years")] Years6To7 = 65536,
    [Description("8-9_years")] Years8To9 = 131072,
    [Description("10-11_years")] Years10To11 = 262144,
    [Description("12-13_years")] Years12To13 = 524288,
    [Description("14-15_years")] Years14To15 = 1048576,
    [Description("16-17_years")] Years16To17 = 2097152,
    [Description("18-19_years")] Years18To19 = 4194304,
    [Description("20-24_years")] Years20To24 = 8388608,
    [Description("20-29_years")] Years20To29 = 16777216,
    [Description("25-29_years")] Years25To29 = 33554432,
    [Description("30-34_years")] Years30To34 = 67108864,
    [Description("30-39_years")] Years30To39 = 134217728,
    [Description("35-39_years")] Years35To39 = 268435456,
    [Description("40-44_years")] Years40To44 = 536870912,
    [Description("40-49_years")] Years40To49 = 1073741824,
    [Description("45-49_years")] Years45To49 = 2147483648,
    [Description("50-54_years")] Years50To54 = 4294967296,
    [Description("50-59_years")] Years50To59 = 8589934592,
    [Description("55-59_years")] Years55To59 = 17179869184,
    [Description("60-64_years")] Years60To64 = 34359738368,
    [Description("60-69_years")] Years60To69 = 68719476736,
    [Description("65-69_years")] Years65To69 = 137438953472,
    [Description("70-79_years")] Years70To79 = 274877906944,
    [Description("80-89_years")] Years80To89 = 549755813888,
    [Description("90_plus_years")] Over90 = 1099511627776,
    [Description("100_over")] Over100 = 2199023255552
}