using bobsbodymetrics.Dtos;
using bobsbodymetrics.Interfaces;
using bobsbodymetrics.Models;

namespace bobsbodymetrics.Service;

public class MonthlyGoalService(IMonthlyGoalRepository monthlyGoalRepository)
{
    private readonly IMonthlyGoalRepository _monthlyGoalRepository = monthlyGoalRepository;

    public IEnumerable<MonthlyGoalDto> GetMonthlyGoals(string userId)
    {
        return _monthlyGoalRepository.GetUserMonthlyGoals(userId).Select(ug => new MonthlyGoalDto
        {
            MonthlyGoalId = ug.MonthlyGoalId,
            UserId = ug.UserId,
            ActivityType = ug.ActivityType,
            Distance = ug.Distance,
            Month = ug.Month,
            Progress = ug.Progress
        });
    }

    public IEnumerable<MonthlyGoalDto> GetMonthlyGoalsByActivityType(string userId, ActivityType activityType)
    {
        return _monthlyGoalRepository.GetUserMonthlyGoalsByActivityType(userId, activityType).Select(ug => new MonthlyGoalDto
        {
            MonthlyGoalId = ug.MonthlyGoalId,
            UserId = ug.UserId,
            ActivityType = ug.ActivityType,
            Distance = ug.Distance,
            Month = ug.Month,
            Progress = ug.Progress
        });
    }

    public IEnumerable<MonthlyGoalDto> GetMonthlyGoalsByMonth(string userId, Month month)
    {
        return _monthlyGoalRepository.GetUserMonthlyGoalsByMonth(userId, month).Select(ug => new MonthlyGoalDto
        {
            MonthlyGoalId = ug.MonthlyGoalId,
            UserId = ug.UserId,
            ActivityType = ug.ActivityType,
            Distance = ug.Distance,
            Month = ug.Month,
            Progress = ug.Progress
        });
    }

    public IEnumerable<MonthlyGoalsByMonthDto> GetMonthlyGoalsByMonth(string userId)
    {
        var groupedGoals = _monthlyGoalRepository.GetUserMonthlyGoalsGroupedByMonth(userId);

        return groupedGoals.Select(g => new MonthlyGoalsByMonthDto
        {
            Month = g.Key,
            Goals = g.Select(ug => new MonthlyGoalDto
            {
                MonthlyGoalId = ug.MonthlyGoalId,
                UserId = ug.UserId,
                ActivityType = ug.ActivityType,
                Distance = ug.Distance,
                Month = ug.Month,
                Progress = ug.Progress
            }).ToList()
        });
    }

    public IEnumerable<MonthlyGoalDto> GetAllMonthlyGoals()
    {
        return _monthlyGoalRepository.GetAll().Select(ug => new MonthlyGoalDto
        {
            MonthlyGoalId = ug.MonthlyGoalId,
            UserId = ug.UserId,
            ActivityType = ug.ActivityType,
            Distance = ug.Distance,
            Month = ug.Month
        });
    }

    public MonthlyGoalDto GetMonthlyGoalById(int id)
    {
        MonthlyGoal ug = _monthlyGoalRepository.GetById(id);
        return new MonthlyGoalDto
        {
            MonthlyGoalId = ug.MonthlyGoalId,
            UserId = ug.UserId,
            ActivityType = ug.ActivityType,
            Distance = ug.Distance,
            Month = ug.Month,
            Progress = ug.Progress
        };
    }

    public void CreateMonthlyGoal(MonthlyGoal monthlyGoal)
    {
        _monthlyGoalRepository.Insert(monthlyGoal);
        _monthlyGoalRepository.Save();
    }

    public void UpdateMonthlyGoal(MonthlyGoal monthlyGoal)
    {
        _monthlyGoalRepository.Update(monthlyGoal);
        _monthlyGoalRepository.Save();
    }

    public void DeleteMonthlyGoal(int id)
    {
        _monthlyGoalRepository.Delete(id);
        _monthlyGoalRepository.Save();
    }

    public void UpdateMonthlyGoalProgress(string userId, Month month, ActivityType activityType, double activityDistance)
    {
        // Fetch the monthly goal for the user for the specific month
        var monthlyGoal = _monthlyGoalRepository.GetAll(g => g.UserId == userId && 
                                                        g.Month == month && g.ActivityType == activityType).FirstOrDefault();

        if (monthlyGoal != null)
        {
            // Update the progress
            monthlyGoal.Progress += activityDistance/1000;
            _monthlyGoalRepository.Update(monthlyGoal);
            _monthlyGoalRepository.Save();
        }
    }
}

