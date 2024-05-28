using bobsbodymetrics.Dtos;
using bobsbodymetrics.Interfaces;
using bobsbodymetrics.Models;

namespace bobsbodymetrics.Service;

public class ActivityService(IActivityRepository activityRepository)
{
    private readonly IActivityRepository _activityRepository = activityRepository;

    public IEnumerable<ActivityDto> GetUserActivities(string userId)
    {
        return _activityRepository.GetUserActivities(userId).Select(a => new ActivityDto
        {
            ActivityId = a.ActivityId,
            UserId = a.UserId,
            DateLogged = a.DateLogged,
            Type = a.Type,
            Duration = a.Duration,
            Distance = a.Distance,
            CaloriesBurned = a.CaloriesBurned,
            AvgHeartRate = a.AvgHeartRate
        });
    }

    public IEnumerable<ActivityDto> GetUserActivitiesByType(string userId, ActivityType activityType)
    {
        return _activityRepository.GetUserActivitiesByType(userId, activityType).Select(a => new ActivityDto
        {
            ActivityId = a.ActivityId,
            UserId = a.UserId,
            DateLogged = a.DateLogged,
            Type = a.Type,
            Duration = a.Duration,
            Distance = a.Distance,
            CaloriesBurned = a.CaloriesBurned,
            AvgHeartRate = a.AvgHeartRate
        });
    }

    public IEnumerable<ActivityDto> GetUserActivitiesByMonth(string userId, DateOnly dateLogged)
    {
        return _activityRepository.GetUserActivitiesByMonth(userId, dateLogged).Select(a => new ActivityDto
        {
            ActivityId = a.ActivityId,
            UserId = a.UserId,
            DateLogged = a.DateLogged,
            Type = a.Type,
            Duration = a.Duration,
            Distance = a.Distance,
            CaloriesBurned = a.CaloriesBurned,
            AvgHeartRate = a.AvgHeartRate
        });
    }
}

