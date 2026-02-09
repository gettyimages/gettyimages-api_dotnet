// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

using System;

namespace GettyImages.Api.Models;

public class Product
{
    public string ApplicationWebsite { get; set; }
    public int? CreditsRemaining { get; set; }
    public int? DownloadLimit { get; set; }
    public string DownloadLimitDuration { get; set; }
    public DateTime? DownloadLimitResetUtcDate { get; set; }
    public int? DownloadsRemaining { get; set; }
    public DateTime? ExpirationUtcDate { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public string Type { get; set; }
    public DownloadRequirements DownloadRequirements { get; set; }
    public OverageDetails Overage { get; set; }
    public string AgreementName { get; set; }
    public string ImagepackResolution { get; set; }
    public int? TeamCredits { get; set; }
}
