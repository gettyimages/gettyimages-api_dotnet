namespace GettyImages.Api.Models;

public enum SortOrderCreative
{
    None = 0,
    [Description("best_match")] BestMatch,
    [Description("most_popular")] MostPopular,
    [Description("newest")] Newest,
    [Description("random")] Random
}