using bobsbodymetrics.Dtos;
using bobsbodymetrics.Interfaces;
using bobsbodymetrics.Models;

namespace bobsbodymetrics.Service;

public class FriendService(IFriendRepository friendRepository)
{
    private readonly IFriendRepository _friendRepository = friendRepository;

    public IEnumerable<FriendDto> GetUserFriends(string userId)
    {
        return _friendRepository.GetUserFriends(userId).Select(f => new FriendDto
        {
            FriendId = f.FriendId,
            UserId = f.UserId,
            FriendUserId = f.FriendUserId,
            FriendReqStatus = f.FriendReqStatus
        });
    }

    public IEnumerable<FriendDto> GetUserFriendRequests(string userId)
    {
        return _friendRepository.GetUserFriendRequests(userId).Select(f => new FriendDto
        {
            FriendId = f.FriendId,
            UserId = f.UserId,
            FriendUserId = f.FriendUserId,
            FriendReqStatus = f.FriendReqStatus
        });
    }

    public IEnumerable<FriendDto> GetUserSentFriendRequests(string userId)
    {
        return _friendRepository.GetUserSentFriendRequests(userId).Select(f => new FriendDto
        {
            FriendId = f.FriendId,
            UserId = f.UserId,
            FriendUserId = f.FriendUserId,
            FriendReqStatus = f.FriendReqStatus
        });
    }

    public IEnumerable<FriendDto> GetAllFriends()
    {
        return _friendRepository.GetAll().Select(f => new FriendDto
        {
            FriendId = f.FriendId,
            UserId = f.UserId,
            FriendUserId = f.FriendUserId,
            FriendReqStatus = f.FriendReqStatus
        });
    }

    public FriendDto GetFriendById(int id)
    {
        Friend f = _friendRepository.GetById(id);

        return new FriendDto
        {
            FriendId = f.FriendId,
            UserId = f.UserId,
            FriendUserId = f.FriendUserId,
            FriendReqStatus = f.FriendReqStatus
        };
    }

    public void CreateFriend(Friend friend)
    {
        _friendRepository.Insert(friend);
        _friendRepository.Save();
    }

    public void UpdateFriend(Friend friend)
    {
        _friendRepository.Update(friend);
        _friendRepository.Save();
    }

    public void DeleteFriend(int id)
    {
        _friendRepository.Delete(id);
        _friendRepository.Save();
    }
}

