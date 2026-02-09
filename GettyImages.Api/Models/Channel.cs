using System;

namespace GettyImages.Api.Models;

public class Channel
{
    public int ChannelId { get; set; }
    public string AssetFamily { get; set; }
    public string ChannelType { get; set; }
    public DateTime StartDate { get; set; }
    public int NotificationCount { get; set; }
    public string AssetType { get; set; }
    public DateTime OldestNotificationDateUtc { get; set; }
}
