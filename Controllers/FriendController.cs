using bobsbodymetrics.Models;
using bobsbodymetrics.Service;
using Microsoft.AspNetCore.Mvc;

namespace bobsbodymetrics.Controllers
{
    [ApiController]
    [Route("friend")]
    public class FriendController(FriendService friendService) : ControllerBase
    {
        private readonly FriendService _friendService = friendService;

        [HttpGet("user/{userId}")]
        public IActionResult GetUserFriends(string userId)
        {
            var friends = _friendService.GetUserFriends(userId);
            return Ok(friends);
        }

        [HttpGet("user/{userId}/requests")]
        public IActionResult GetUserFriendRequests(string userId)
        {
            var friendRequests = _friendService.GetUserFriendRequests(userId);
            return Ok(friendRequests);
        }

        [HttpGet("user/{userId}/sent-requests")]
        public IActionResult GetUserSentFriendRequests(string userId)
        {
            var sentRequests = _friendService.GetUserSentFriendRequests(userId);
            return Ok(sentRequests);
        }

        [HttpGet]
        public IActionResult GetAllFriends()
        {
            var friends = _friendService.GetAllFriends();
            return Ok(friends);
        }

        [HttpGet("{id}")]
        public IActionResult GetFriendById(int id)
        {
            var friend = _friendService.GetFriendById(id);
            if (friend == null)
            {
                return NotFound();
            }
            return Ok(friend);
        }

        [HttpPost]
        public IActionResult CreateFriend([FromBody] Friend friend)
        {
            if (friend == null)
            {
                return BadRequest();
            }

            _friendService.CreateFriend(friend);
            return CreatedAtAction(nameof(GetFriendById), new { id = friend.FriendId }, friend);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFriend(int id, [FromBody] Friend friend)
        {
            if (friend == null || friend.FriendId != id)
            {
                return BadRequest();
            }

            var existingFriend = _friendService.GetFriendById(id);
            if (existingFriend == null)
            {
                return NotFound();
            }

            _friendService.UpdateFriend(friend);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFriend(int id)
        {
            var friend = _friendService.GetFriendById(id);
            if (friend == null)
            {
                return NotFound();
            }

            _friendService.DeleteFriend(id);
            return NoContent();
        }
    }
}
