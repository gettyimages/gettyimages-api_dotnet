using System;

namespace GettyImages.Api.Models;

[Flags]
public enum OrientationImages
{
    None = 0,
    Horizontal = 1,
    Panoramic_Horizontal = 2,
    Panoramic_Vertical = 4,
    Square = 8,
    Vertical = 16
}
