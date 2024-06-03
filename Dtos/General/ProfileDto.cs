using bobsbodymetrics.Models;

namespace bobsbodymetrics.Dtos;

public class PublicProfileDto
{
    public string UserId { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string? ProfileImg { get; set; }
    public string? BgImg { get; set; }
    public string? ProfileColor { get; set; }
    public string? Bio { get; set; }
    public Gender Gender { get; set; }

}

public class PublicProfileShortDto
{
    public string UserId { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public int Age { get; set; }
    public string? ProfileImg { get; set; }
}

public class PublicProfileShortWithFSDto
{
    public string UserId { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public FriendReqStatus FriendStatus { get; set; }
    public Gender Gender { get; set; }
    public int Age { get; set; }
    public string? ProfileImg { get; set; }
}

public class PrivateProfileDto
{
    public string UserId { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }
    public Gender Gender { get; set; }
    public string? ProfileImg { get; set; }
    public string? BgImg { get; set; }
    public string? ProfileColor { get; set; }
    public string? Bio { get; set; }
    public bool IsPublic { get; set; }
}