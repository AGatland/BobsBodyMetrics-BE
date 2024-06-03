using System.Security.Authentication;
using bobsbodymetrics.Dtos;
using bobsbodymetrics.Interfaces;
using bobsbodymetrics.Models;

namespace bobsbodymetrics.Service;

public class ActivityService(IActivityRepository activityRepository, MonthlyGoalService monthlyGoalService)
{
    private readonly IActivityRepository _activityRepository = activityRepository;
    private readonly MonthlyGoalService _monthlyGoalService = monthlyGoalService;

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

    public IEnumerable<ActivityDto> GetUserActivitiesByFriends(string userId)
    {
        return _activityRepository.GetUserActivitiesByFriends(userId).Select(a => new ActivityDto
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

        // Update the monthly goal progress
        var currentMonth = (Month)DateTime.Now.Month - 1;
        _monthlyGoalService.UpdateMonthlyGoalProgress(activity.UserId, currentMonth, activity.Type, activity.Distance);
    }

    public void UpdateActivity(Activity activity)
    {
        _activityRepository.Update(activity);
        _activityRepository.Save();

        // Update the monthly goal progress
        var currentMonth = (Month)DateTime.Now.Month - 1;
        _monthlyGoalService.UpdateMonthlyGoalProgress(activity.UserId, currentMonth, activity.Type, activity.Distance);
    }

    public void DeleteActivity(int id)
    {
        _activityRepository.Delete(id);
        _activityRepository.Save();
    }
}

