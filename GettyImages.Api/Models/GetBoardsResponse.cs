// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GettyImages.Api.Models;

public class GetBoardsResponse
{
    public BoardBasic[] Boards { get; set; }
    public int BoardCount { get; set; }
}