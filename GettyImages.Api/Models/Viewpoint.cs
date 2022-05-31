using System;

namespace GettyImages.Api.Models
{
    [Flags]
    public enum Viewpoint : long
    {
        None = 0,
        [Description("lockdown")] Lockdown = 1,
        [Description("panning")] Panning = 2,
        [Description("tracking_shot")] TrackingShot = 4,
        [Description("aerial_view")] AerialView = 8,
        [Description("high_angle_view")] HighAngleView = 16,
        [Description("low_angle_view")] LowAngleView = 32,
        [Description("tilt")] Tilt = 64,
        [Description("point_of_view")] PointOfView = 128
    }
}
