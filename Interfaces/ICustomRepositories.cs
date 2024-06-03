using bobsbodymetrics.Dtos;
using bobsbodymetrics.Models;

namespace bobsbodymetrics.Interfaces;

public interface IProfileRepository : IDatabaseRepository<Profile>
{
    Profile GetUserProfile(string userId);
    Profile GetUserProfileByUsername(string username);
    IEnumerable<PublicProfileShortDto> GetAllUserProfilesShortWithUsername();
    IEnumerable<PublicProfileShortWithFSDto> GetAllUserProfilesShortWithFriendStatus(string userId);
}

public interface IActivityRepository : IDatabaseRepository<Activity>
{
    IEnumerable<Activity> GetUserActivities(string userId);
    IEnumerable<Activity> GetUserActivitiesByType(string userId, ActivityType activityType);
    IEnumerable<Activity> GetUserActivitiesByMonth(string userId, DateOnly dateLogged);
    IEnumerable<Activity> GetUserActivitiesByFriends(string userId);

}

public interface IActivityPBRepository : IDatabaseRepository<ActivityPB>
{
    IEnumerable<ActivityPB> GetUserPBs(string userId);
    IEnumerable<ActivityPB> GetUserPBsByActivityType(string userId, ActivityType activityType);
}

public interface IMonthlyGoalRepository : IDatabaseRepository<MonthlyGoal>
{
    IEnumerable<MonthlyGoal> GetUserMonthlyGoals(string userId);
    IEnumerable<MonthlyGoal> GetUserMonthlyGoalsByActivityType(string userId, ActivityType activityType);
    IEnumerable<MonthlyGoal> GetUserMonthlyGoalsByMonth(string userId, Month month);
    IEnumerable<IGrouping<Month, MonthlyGoal>> GetUserMonthlyGoalsGroupedByMonth(string userId);
}

public interface IFriendRepository : IDatabaseRepository<Friend>
{
    IEnumerable<Friend> GetUserFriends(string userId);
    IEnumerable<Friend> GetUserFriendRequests(string userId);
    IEnumerable<Friend> GetUserSentFriendRequests(string userId);

}
