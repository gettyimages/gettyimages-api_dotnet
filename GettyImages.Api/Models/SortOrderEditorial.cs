﻿namespace GettyImages.Api.Models;

public enum SortOrderEditorial
{
    None = 0,
    [Description("best_match")] BestMatch,
    [Description("most_popular")] MostPopular,
    [Description("newest")] Newest,
    [Description("oldest")] Oldest,
    [Description("random")] Random
}