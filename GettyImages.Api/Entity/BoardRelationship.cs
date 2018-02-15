namespace GettyImages.Api.Entity
{
    public enum BoardRelationship
    {
        None = 0,
        [Description("owned")] Owned = 1,
        [Description("invited")] Invited = 2
    }
}
