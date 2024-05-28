using bobsbodymetrics.Models;

namespace bobsbodymetrics.Dtos;

public class FriendDto
{
    public int FriendId { get; set; }
    public string UserId { get; set; }
    public string FriendUserId { get; set; }
    public FriendReqStatus FriendReqStatus { get; set; }
}

