using bobsbodymetrics.Data;
using bobsbodymetrics.Interfaces;
using bobsbodymetrics.Models;
using Microsoft.EntityFrameworkCore;

namespace bobsbodymetrics.Repository;

public class ActivityRepository(ApplicationDbContext db) : DatabaseRepository<Activity>(db), IActivityRepository
{
    public IEnumerable<Activity> GetUserActivities(string userId)
    {
        return _db.Activities.Where(a => a.UserId == userId).ToList();
    }

    public IEnumerable<Activity> GetUserActivitiesByType(string userId, ActivityType activityType)
    {
        return _db.Activities.Where(a => a.UserId == userId && a.Type == activityType).ToList();
    }

    public IEnumerable<Activity> GetUserActivitiesByMonth(string userId, DateOnly dateLogged)
    {
        return _db.Activities.Where(a => a.UserId == userId && a.DateLogged.Month == dateLogged.Month && a.DateLogged.Year == dateLogged.Year).ToList();
    }
}

public class ActivityPBRepository(ApplicationDbContext db) : DatabaseRepository<ActivityPB>(db), IActivityPBRepository
{
    public IEnumerable<ActivityPB> GetUserPBs(string userId)
    {
        return _db.ActivityPBs.Where(pb => pb.UserId == userId).ToList();
    }

    public IEnumerable<ActivityPB> GetUserPBsByActivityType(string userId, ActivityType activityType)
    {
        return _db.ActivityPBs.Where(pb => pb.UserId == userId && pb.ActivityType == activityType).ToList();
    }
}

public class ProfileRepository(ApplicationDbContext db) : DatabaseRepository<Profile>(db), IProfileRepository
{
    public Profile GetUserProfile(string userId)
    {
        return _db.Profiles.FirstOrDefault(p => p.UserId == userId);
    }

    public Profile GetUserProfileByUsername(string username)
        {
            return _db.Profiles
                      .Include(p => p.User)
                      .FirstOrDefault(p => p.User.UserName == username);
        }
}

public class UserGoalRepository(ApplicationDbContext db) : DatabaseRepository<UserGoal>(db), IUserGoalRepository
{
    public IEnumerable<UserGoal> GetUserGoals(string userId)
    {
        return _db.UserGoals.Where(ug => ug.UserId == userId).ToList();
    }

    public IEnumerable<UserGoal> GetUserGoalsByActivityType(string userId, ActivityType activityType)
    {
        return _db.UserGoals.Where(ug => ug.UserId == userId && ug.ActivityType == activityType).ToList();
    }
}

public class FriendRepository(ApplicationDbContext db) : DatabaseRepository<Friend>(db), IFriendRepository
{
    public IEnumerable<Friend> GetUserFriends(string userId)
    {
        return _db.Friends.Where(f => f.UserId == userId && f.FriendReqStatus == FriendReqStatus.ACCEPTED).ToList();
    }

    public IEnumerable<Friend> GetUserFriendRequests(string userId)
    {
        return _db.Friends.Where(f => f.FriendUserId == userId && f.FriendReqStatus == FriendReqStatus.PENDING).ToList();
    }

    public IEnumerable<Friend> GetUserSentFriendRequests(string userId)
    {
        return _db.Friends.Where(f => f.UserId == userId && f.FriendReqStatus == FriendReqStatus.PENDING).ToList();
    }
}