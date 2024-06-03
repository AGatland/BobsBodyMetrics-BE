
namespace bobsbodymetrics.Models;

public enum Month {
    JAN,
    FEB,
    MAR,
    APR,
    MAY,
    JUN,
    JUL,
    AUG,
    SEP,
    OCT,
    NOV,
    DEC
}

public class MonthlyGoal
{
    public int MonthlyGoalId { get; set;}
    public string? UserId { get; set;}
    public ActivityType ActivityType { get; set;}
    public double Distance { get; set;}
    public double Progress { get; set;} = 0;
    public Month Month {get; set;}
}