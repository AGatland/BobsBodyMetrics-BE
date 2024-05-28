
namespace bobsbodymetrics.Models;

public enum DistanceType {
    KM1,
    KM3,
    KM5,
    KM10
}

public class ActivityPB
{
    public int ActivityPBId { get; set;}
    public string? UserId { get; set; }
    public ActivityType ActivityType { get; set; }
    public DistanceType DistanceType { get; set; }
    public double Duration { get; set; }

}