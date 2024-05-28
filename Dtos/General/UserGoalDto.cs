using bobsbodymetrics.Models;

namespace bobsbodymetrics.Dtos;

public class UserGoalDto
{
    public int UserGoalId { get; set; }
    public string UserId { get; set; }
    public ActivityType ActivityType { get; set; }
    public double Distance { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}

