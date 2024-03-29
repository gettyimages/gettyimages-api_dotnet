using System.Runtime.Serialization;

namespace GettyImages.Api.Models;

public enum ImageGenerationsSize
{
    [EnumMember(Value = "1k")] OneK = 1,
    [EnumMember(Value = "4k")] FourK = 2
}