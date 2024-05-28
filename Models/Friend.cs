
namespace bobsbodymetrics.Models;

public enum FriendReqStatus {
    PENDING,
    ACCEPTED
}

public class Friend
{
    public int FriendId { get; set;}
    public int UserId { get; set;}
    public int FriendUserId { get; set;}
    public FriendReqStatus FriendReqStatus { get; set;}

}