using bobsbodymetrics.Service;
using bobsbodymetrics.Models;
using Microsoft.AspNetCore.Mvc;

namespace bobsbodymetrics.Controllers
{
    [ApiController]
    [Route("activity")]
    public class ActivityController(ActivityService activityService) : ControllerBase
    {
        private readonly ActivityService _activityService = activityService;

        [HttpGet("user/{userId}")]
        public IActionResult GetUserActivities(string userId)
        {
            var activities = _activityService.GetUserActivities(userId);
            return Ok(activities);
        }

        [HttpGet("user/{userId}/type/{activityType}")]
        public IActionResult GetUserActivitiesByType(string userId, ActivityType activityType)
        {
            var activities = _activityService.GetUserActivitiesByType(userId, activityType);
            return Ok(activities);
        }

        [HttpGet("user/{userId}/month/{dateLogged}")]
        public IActionResult GetUserActivitiesByMonth(string userId, DateOnly dateLogged)
        {
            var activities = _activityService.GetUserActivitiesByMonth(userId, dateLogged);
            return Ok(activities);
        }

        [HttpGet]
        public IActionResult GetAllActivities()
        {
            var activities = _activityService.GetAllActivities();
            return Ok(activities);
        }

        [HttpGet("{id}")]
        public IActionResult GetActivityById(int id)
        {
            var activity = _activityService.GetActivityById(id);
            if (activity == null)
            {
                return NotFound();
            }
            return Ok(activity);
        }

        [HttpPost]
        public IActionResult CreateActivity([FromBody] Activity activity)
        {
            if (activity == null)
            {
                return BadRequest();
            }

            _activityService.CreateActivity(activity);
            return CreatedAtAction(nameof(GetActivityById), new { id = activity.ActivityId }, activity);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateActivity(int id, [FromBody] Activity activity)
        {
            if (activity == null || activity.ActivityId != id)
            {
                return BadRequest();
            }

            var existingActivity = _activityService.GetActivityById(id);
            if (existingActivity == null)
            {
                return NotFound();
            }

            _activityService.UpdateActivity(activity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActivity(int id)
        {
            var activity = _activityService.GetActivityById(id);
            if (activity == null)
            {
                return NotFound();
            }

            _activityService.DeleteActivity(id);
            return NoContent();
        }
    }
}
