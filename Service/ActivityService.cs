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

    public IEnumerable<ActivityDto> GetAllActivities()
    {
        return _activityRepository.GetAll().Select(a => new ActivityDto
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

    public ActivityDto GetActivityById(int id)
    {
        Activity a = _activityRepository.GetById(id);
        
        return new ActivityDto
        {
            ActivityId = a.ActivityId,
            UserId = a.UserId,
            DateLogged = a.DateLogged,
            Type = a.Type,
            Duration = a.Duration,
            Distance = a.Distance,
            CaloriesBurned = a.CaloriesBurned,
            AvgHeartRate = a.AvgHeartRate
        };
    }

    public void CreateActivity(Activity activity)
    {
        _activityRepository.Insert(activity);
        _activityRepository.Save();
    }

    public void UpdateActivity(Activity activity)
    {
        _activityRepository.Update(activity);
        _activityRepository.Save();
    }

    public void DeleteActivity(int id)
    {
        _activityRepository.Delete(id);
        _activityRepository.Save();
    }
}

