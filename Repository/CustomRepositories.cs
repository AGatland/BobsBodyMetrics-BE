using bobsbodymetrics.Data;
using bobsbodymetrics.Interfaces;
using bobsbodymetrics.Models;
using bobsbodymetrics.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.Extensions.ObjectPool;
using Microsoft.EntityFrameworkCore.Internal;
using bobsbodymetrics.Service;

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

    public IEnumerable<Activity> GetUserActivitiesByFriends(string userId)
    {
        // Get the list of friend IDs where the user can be either UserId or FriendUserId
        var friendIds = _db.Friends
                        .Where(f => f.UserId == userId || f.FriendUserId == userId)
                        .Select(f => f.UserId == userId ? f.FriendUserId : f.UserId)
                        .ToList();

        return _db.Activities.Where(a => friendIds.Contains(a.UserId)).ToList();
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
                    .FirstOrDefault(p => p.User.UserName.ToLower() == username.ToLower());
    }

    public IEnumerable<PublicProfileShortDto> GetAllUserProfilesShortWithUsername()
    {
        return _db.Profiles
                        .Include(p => p.User)
                        .Select(profile => new PublicProfileShortDto
                            {
                                UserId = profile.UserId,
                                Name = profile.Name,
                                UserName = profile.User.UserName,
                                Age = profile.Age,
                                ProfileImg = profile.ProfileImg,
                            }).ToList();
    }

public IEnumerable<PublicProfileShortWithFSDto> GetAllUserProfilesShortWithFriendStatus(string userId)
{
    // Retrieve friend relationships
    var friendIds = _db.Friends
                        .Where(f => f.UserId == userId || f.FriendUserId == userId)
                        .Select(f => new 
                        {
                            FriendId = f.UserId == userId ? f.FriendUserId : f.UserId,
                            Status = f.FriendReqStatus
                        })
                        .ToList();

    // Create a dictionary to hold the status for each friend ID
    var friendStatusDict = friendIds.ToDictionary(f => f.FriendId, f => f.Status);

    // Retrieve profiles with initial FriendStatus set to NONE
    var profiles = _db.Profiles
                      .Include(p => p.User)
                      .Select(p => new PublicProfileShortWithFSDto
                      {
                          UserId = p.UserId,
                          Name = p.Name,
                          UserName = p.User.UserName,
                          Age = p.Age,
                          Gender = p.Gender,
                          ProfileImg = p.ProfileImg,
                          FriendStatus = FriendReqStatus.NONE
                      }).ToList();

    // Update FriendStatus based on the dictionary
    foreach (var profile in profiles)
    {
        if (friendStatusDict.TryGetValue(profile.UserId, out var status))
        {
            profile.FriendStatus = status;
        }
    }

    return profiles;
}

}

public class MonthlyGoalRepository(ApplicationDbContext db) : DatabaseRepository<MonthlyGoal>(db), IMonthlyGoalRepository
{
    public IEnumerable<MonthlyGoal> GetUserMonthlyGoals(string userId)
    {
        return _db.MonthlyGoals.Where(ug => ug.UserId == userId).ToList();
    }

    public IEnumerable<MonthlyGoal> GetUserMonthlyGoalsByActivityType(string userId, ActivityType activityType)
    {
        return _db.MonthlyGoals.Where(ug => ug.UserId == userId && ug.ActivityType == activityType).ToList();
    }

    public IEnumerable<MonthlyGoal> GetUserMonthlyGoalsByMonth(string userId, Month month)
    {
        return _db.MonthlyGoals.Where(ug => ug.UserId == userId && ug.Month == month).ToList();
    }

    public IEnumerable<IGrouping<Month, MonthlyGoal>> GetUserMonthlyGoalsGroupedByMonth(string userId)
    {
        return _db.MonthlyGoals
                .Where(ug => ug.UserId == userId)
                .GroupBy(ug => ug.Month)
                .ToList();
    }
}

public class FriendRepository(ApplicationDbContext db) : DatabaseRepository<Friend>(db), IFriendRepository
{
    public IEnumerable<Friend> GetUserFriends(string userId)
    {
        return _db.Friends.Where(f => (f.UserId == userId || f.FriendUserId == userId) && f.FriendReqStatus == FriendReqStatus.ACCEPTED).ToList();
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