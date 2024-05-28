using bobsbodymetrics.Dtos;
using bobsbodymetrics.Interfaces;
using bobsbodymetrics.Models;

namespace bobsbodymetrics.Service;

public class UserGoalService(IUserGoalRepository userGoalRepository)
{
    private readonly IUserGoalRepository _userGoalRepository = userGoalRepository;

    public IEnumerable<UserGoalDto> GetUserGoals(string userId)
    {
        return _userGoalRepository.GetUserGoals(userId).Select(ug => new UserGoalDto
        {
            UserGoalId = ug.UserGoalId,
            UserId = ug.UserId,
            ActivityType = ug.ActivityType,
            Distance = ug.Distance,
            StartDate = ug.StartDate,
            EndDate = ug.EndDate
        });
    }

    public IEnumerable<UserGoalDto> GetUserGoalsByActivityType(string userId, ActivityType activityType)
    {
        return _userGoalRepository.GetUserGoalsByActivityType(userId, activityType).Select(ug => new UserGoalDto
        {
            UserGoalId = ug.UserGoalId,
            UserId = ug.UserId,
            ActivityType = ug.ActivityType,
            Distance = ug.Distance,
            StartDate = ug.StartDate,
            EndDate = ug.EndDate
        });
    }
}

