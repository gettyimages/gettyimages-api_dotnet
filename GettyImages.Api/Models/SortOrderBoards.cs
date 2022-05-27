namespace GettyImages.Api.Models
{
    public enum SortOrderBoards
    {
        None = 0,
        [Description("date_last_updated_descending")] DateLastUpdatedDescending,
        [Description("date_last_updated_ascending")] DateLastUpdatedAscending,
        [Description("name_ascending")] NameAscending,
        [Description("name_decending")] NameDescending
    }
}
