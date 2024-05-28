using bobsbodymetrics.Dtos;
using bobsbodymetrics.Interfaces;
using bobsbodymetrics.Models;

namespace bobsbodymetrics.Services
{
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
    }
}
