using System;

namespace GettyImages.Api.Models
{
    [Flags]
    public enum OrientationImagesResponse
    {
        None = 0,
        Horizontal = 1,
        PanoramicHorizontal = 2,
        PanoramicVertical = 4,
        Square = 8,
        Vertical = 16,
        Unknown = 32
    }
}
