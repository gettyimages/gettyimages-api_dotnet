﻿namespace GettyImages.Api.Models;

public enum GraphicalStyleFilter
{
    None = 0,
    [Description("include")] Include = 1,
    [Description("exclude")] Exclude = 2
}