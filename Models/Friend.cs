
namespace bobsbodymetrics.Models;

public enum FriendReqStatus {
    NONE,
    PENDING,
    ACCEPTED
}

public class Friend
{
    public int FriendId { get; set;}
    public string? UserId { get; set;}
    public string? FriendUserId { get; set;}
    public FriendReqStatus FriendReqStatus { get; set;} = FriendReqStatus.PENDING;

}