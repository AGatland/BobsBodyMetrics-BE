using bobsbodymetrics.Dtos;
using bobsbodymetrics.Interfaces;
using bobsbodymetrics.Models;

namespace bobsbodymetrics.Service;

public class ActivityPBService(IActivityPBRepository activityPBRepository)
{
    private readonly IActivityPBRepository _activityPBRepository = activityPBRepository;

    public IEnumerable<ActivityPBDto> GetUserPBs(string userId)
    {
        return _activityPBRepository.GetUserPBs(userId).Select(pb => new ActivityPBDto
        {
            ActivityPBId = pb.ActivityPBId,
            UserId = pb.UserId,
            ActivityType = pb.ActivityType,
            DistanceType = pb.DistanceType,
            Duration = pb.Duration
        });
    }

    public IEnumerable<ActivityPBDto> GetUserPBsByActivityType(string userId, ActivityType activityType)
    {
        return _activityPBRepository.GetUserPBsByActivityType(userId, activityType).Select(pb => new ActivityPBDto
        {
            ActivityPBId = pb.ActivityPBId,
            UserId = pb.UserId,
            ActivityType = pb.ActivityType,
            DistanceType = pb.DistanceType,
            Duration = pb.Duration
        });
    }
}

