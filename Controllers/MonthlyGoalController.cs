using bobsbodymetrics.Service;
using bobsbodymetrics.Models;
using Microsoft.AspNetCore.Mvc;

namespace bobsbodymetrics.Controllers
{
    [ApiController]
    [Route("goal")]
    public class MonthlyGoalController(MonthlyGoalService monthlyGoalService) : ControllerBase
    {
        private readonly MonthlyGoalService _monthlyGoalService = monthlyGoalService;

        [HttpGet("user/{userId}")]
        public IActionResult GetMonthlyGoals(string userId)
        {
            var goals = _monthlyGoalService.GetMonthlyGoals(userId);
            return Ok(goals);
        }

        [HttpGet("user/{userId}/type/{activityType}")]
        public IActionResult GetMonthlyGoalsByActivityType(string userId, ActivityType activityType)
        {
            var goals = _monthlyGoalService.GetMonthlyGoalsByActivityType(userId, activityType);
            return Ok(goals);
        }

        [HttpGet("user/{userId}/month/{month}")]
        public IActionResult GetMonthlyGoalsByMonth(string userId, Month month)
        {
            var goals = _monthlyGoalService.GetMonthlyGoalsByMonth(userId, month);
            return Ok(goals);
        }

        [HttpGet("user/{userId}/month")]
        public IActionResult GetMonthlyGoalsByMonth(string userId)
        {
            var goals = _monthlyGoalService.GetMonthlyGoalsByMonth(userId);
            return Ok(goals);
        }

         [HttpGet]
        public IActionResult GetAllMonthlyGoals()
        {
            var goals = _monthlyGoalService.GetAllMonthlyGoals();
            return Ok(goals);
        }

        [HttpGet("{id}")]
        public IActionResult GetMonthlyGoalById(int id)
        {
            var goal = _monthlyGoalService.GetMonthlyGoalById(id);
            if (goal == null)
            {
                return NotFound();
            }
            return Ok(goal);
        }

        [HttpPost]
        public IActionResult CreateMonthlyGoal([FromBody] MonthlyGoal monthlyGoal)
        {
            if (monthlyGoal == null)
            {
                return BadRequest();
            }

            _monthlyGoalService.CreateMonthlyGoal(monthlyGoal);
            return CreatedAtAction(nameof(GetMonthlyGoalById), new { id = monthlyGoal.MonthlyGoalId }, monthlyGoal);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMonthlyGoal(int id, [FromBody] MonthlyGoal monthlyGoal)
        {
            if (monthlyGoal == null || monthlyGoal.MonthlyGoalId != id)
            {
                return BadRequest();
            }

            var existingGoal = _monthlyGoalService.GetMonthlyGoalById(id);
            if (existingGoal == null)
            {
                return NotFound();
            }

            _monthlyGoalService.UpdateMonthlyGoal(monthlyGoal);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMonthlyGoal(int id)
        {
            var goal = _monthlyGoalService.GetMonthlyGoalById(id);
            if (goal == null)
            {
                return NotFound();
            }

            _monthlyGoalService.DeleteMonthlyGoal(id);
            return NoContent();
        }
    }
}
