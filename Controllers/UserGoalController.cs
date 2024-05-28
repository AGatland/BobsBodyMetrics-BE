using bobsbodymetrics.Service;
using bobsbodymetrics.Models;
using Microsoft.AspNetCore.Mvc;

namespace bobsbodymetrics.Controllers
{
    [ApiController]
    [Route("goal")]
    public class UserGoalController(UserGoalService userGoalService) : ControllerBase
    {
        private readonly UserGoalService _userGoalService = userGoalService;

        [HttpGet("user/{userId}")]
        public IActionResult GetUserGoals(string userId)
        {
            var goals = _userGoalService.GetUserGoals(userId);
            return Ok(goals);
        }

        [HttpGet("user/{userId}/type/{activityType}")]
        public IActionResult GetUserGoalsByActivityType(string userId, ActivityType activityType)
        {
            var goals = _userGoalService.GetUserGoalsByActivityType(userId, activityType);
            return Ok(goals);
        }

         [HttpGet]
        public IActionResult GetAllUserGoals()
        {
            var goals = _userGoalService.GetAllUserGoals();
            return Ok(goals);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserGoalById(int id)
        {
            var goal = _userGoalService.GetUserGoalById(id);
            if (goal == null)
            {
                return NotFound();
            }
            return Ok(goal);
        }

        [HttpPost]
        public IActionResult CreateUserGoal([FromBody] UserGoal userGoal)
        {
            if (userGoal == null)
            {
                return BadRequest();
            }

            _userGoalService.CreateUserGoal(userGoal);
            return CreatedAtAction(nameof(GetUserGoalById), new { id = userGoal.UserGoalId }, userGoal);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUserGoal(int id, [FromBody] UserGoal userGoal)
        {
            if (userGoal == null || userGoal.UserGoalId != id)
            {
                return BadRequest();
            }

            var existingGoal = _userGoalService.GetUserGoalById(id);
            if (existingGoal == null)
            {
                return NotFound();
            }

            _userGoalService.UpdateUserGoal(userGoal);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUserGoal(int id)
        {
            var goal = _userGoalService.GetUserGoalById(id);
            if (goal == null)
            {
                return NotFound();
            }

            _userGoalService.DeleteUserGoal(id);
            return NoContent();
        }
    }
}
