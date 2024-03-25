using System.Runtime.Serialization;

namespace GettyImages.Api.Models;

public enum ImageGenerationsMediaType
{
    None = 0,
    [EnumMember(Value = "photography")] Photography = 1,
    [EnumMember(Value = "illustration")] Illustration = 2
}