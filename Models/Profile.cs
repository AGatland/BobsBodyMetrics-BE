
namespace bobsbodymetrics.Models;

public enum Gender {
    MALE,
    FEMALE,
    OTHER
}

public class Profile
{
    public int ProfileId { get; set; }
    public string? UserId { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }
    public Gender Gender { get; set; }
}