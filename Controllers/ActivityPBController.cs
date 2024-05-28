using bobsbodymetrics.Service;
using bobsbodymetrics.Models;
using Microsoft.AspNetCore.Mvc;

namespace bobsbodymetrics.Controllers
{
    [ApiController]
    [Route("pb")]
    public class ActivityPBController(ActivityPBService activityPBService) : ControllerBase
    {
        private readonly ActivityPBService _activityPBService = activityPBService;

        [HttpGet("user/{userId}")]
        public IActionResult GetUserPBs(string userId)
        {
            var pbs = _activityPBService.GetUserPBs(userId);
            return Ok(pbs);
        }

        [HttpGet("user/{userId}/type/{activityType}")]
        public IActionResult GetUserPBsByActivityType(string userId, ActivityType activityType)
        {
            var pbs = _activityPBService.GetUserPBsByActivityType(userId, activityType);
            return Ok(pbs);
        }

        [HttpGet]
        public IActionResult GetAllActivityPBs()
        {
            var pbs = _activityPBService.GetAllActivityPBs();
            return Ok(pbs);
        }

        [HttpGet("{id}")]
        public IActionResult GetActivityPBById(int id)
        {
            var pb = _activityPBService.GetActivityPBById(id);
            if (pb == null)
            {
                return NotFound();
            }
            return Ok(pb);
        }

        [HttpPost]
        public IActionResult CreateActivityPB([FromBody] ActivityPB activityPB)
        {
            if (activityPB == null)
            {
                return BadRequest();
            }

            _activityPBService.CreateActivityPB(activityPB);
            return CreatedAtAction(nameof(GetActivityPBById), new { id = activityPB.ActivityPBId }, activityPB);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateActivityPB(int id, [FromBody] ActivityPB activityPB)
        {
            if (activityPB == null || activityPB.ActivityPBId != id)
            {
                return BadRequest();
            }

            var existingPB = _activityPBService.GetActivityPBById(id);
            if (existingPB == null)
            {
                return NotFound();
            }

            _activityPBService.UpdateActivityPB(activityPB);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActivityPB(int id)
        {
            var pb = _activityPBService.GetActivityPBById(id);
            if (pb == null)
            {
                return NotFound();
            }

            _activityPBService.DeleteActivityPB(id);
            return NoContent();
        }
    }
}
