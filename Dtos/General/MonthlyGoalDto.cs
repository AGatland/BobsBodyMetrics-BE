using bobsbodymetrics.Models;

namespace bobsbodymetrics.Dtos;

public class MonthlyGoalDto
{
    public int MonthlyGoalId { get; set; }
    public string UserId { get; set; }
    public ActivityType ActivityType { get; set; }
    public double Distance { get; set; }
    public double Progress { get; set; }
    public Month Month {get; set;}
}

public class MonthlyGoalsByMonthDto
{
    public Month Month { get; set; }
    public List<MonthlyGoalDto> Goals { get; set; }
}