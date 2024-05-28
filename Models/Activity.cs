
namespace bobsbodymetrics.Models;

public enum ActivityType {
    RUNNING,
    SWIMMING,
    CYCLING,
    WALKING,
    ROLLERSKATING
}

public class Activity
{
    public int ActivityId { get; set;}
    public int UserId { get; set; }
    public DateTime DateLogged { get; set; } = DateTime.UtcNow;
    public ActivityType Type { get; set; }
    public double Duration { get; set; }
    public double Distance { get; set; }
    public double CaloriesBurned { get; set; }
    public double AvgHeartRate { get; set; }
}
