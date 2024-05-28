using bobsbodymetrics.Models;

namespace bobsbodymetrics.Dtos;

public class ActivityPBDto
{
    public int ActivityPBId { get; set; }
    public string UserId { get; set; }
    public ActivityType ActivityType { get; set; }
    public DistanceType DistanceType { get; set; }
    public double Duration { get; set; }
}
