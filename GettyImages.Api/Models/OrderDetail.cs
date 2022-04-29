// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

using System;

namespace GettyImages.Api.Models;

public class OrderDetail
{
    public string Id { get; set; }
    public string InvoiceNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public string EndClient { get; set; }
    public OrderNotes Notes { get; set; }
    public AssetIdFromOrder[] Assets { get; set; }
}