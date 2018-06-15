namespace GettyImages.Api.Entity
{
    public enum ReleaseStatus
    {
        None = 0,
        [Description("release_not_important")] ReleaseNotImportant = 1,
        [Description("fully_released")] FullyReleased = 2
    }
}
