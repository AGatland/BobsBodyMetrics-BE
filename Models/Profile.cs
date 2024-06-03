
using Microsoft.AspNetCore.Identity;

namespace bobsbodymetrics.Models;

public enum Gender {
    UNSPECIFIED,
    MALE,
    FEMALE,
    OTHER
}

public class Profile
{
    public int ProfileId { get; set; }
    public string? UserId { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }

    // Public info
    public bool IsPublic { get; set; } = true;

    public string? Name { get; set; }
    public int Age { get; set; }
    public string Bio { get; set; } = "";
    public string? ProfileImg { get; set; }
    public string? BgImg { get; set; }
    public string? ProfileColor { get; set; }
    public Gender Gender { get; set; } = Gender.UNSPECIFIED;


    // Navigation property to AppUser
    public IdentityUser User { get; set; }
}