// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public class BoardPermissions
{
    public bool CanDeleteBoard { get; set; }
    public bool CanInviteToBoard { get; set; }
    public bool CanUpdateName { get; set; }
    public bool CanUpdateDescription { get; set; }
    public bool CanAddAssets { get; set; }
    public bool CanRemoveAssets { get; set; }
}