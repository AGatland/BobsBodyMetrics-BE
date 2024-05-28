using bobsbodymetrics.Models;

namespace bobsbodymetrics.Interfaces;

public interface IProfileRepository : IDatabaseRepository<Profile>
{
    Profile GetUserProfile(string userId);
    Profile GetUserProfileByUsername(string username);
}

public interface IActivityRepository : IDatabaseRepository<Activity>
{
    IEnumerable<Activity> GetUserActivities(string userId);
    IEnumerable<Activity> GetUserActivitiesByType(string userId, ActivityType activityType);
    IEnumerable<Activity> GetUserActivitiesByMonth(string userId, DateOnly dateLogged);

}

public interface IActivityPBRepository : IDatabaseRepository<ActivityPB>
{
    IEnumerable<ActivityPB> GetUserPBs(string userId);
    IEnumerable<ActivityPB> GetUserPBsByActivityType(string userId, ActivityType activityType);
}

public interface IUserGoalRepository : IDatabaseRepository<UserGoal>
{
    IEnumerable<UserGoal> GetUserGoals(string userId);
    IEnumerable<UserGoal> GetUserGoalsByActivityType(string userId, ActivityType activityType);
    
}

public interface IFriendRepository : IDatabaseRepository<Friend>
{
    IEnumerable<Friend> GetUserFriends(string userId);
    IEnumerable<Friend> GetUserFriendRequests(string userId);
    IEnumerable<Friend> GetUserSentFriendRequests(string userId);

}
