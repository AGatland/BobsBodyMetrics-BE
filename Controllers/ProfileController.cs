using bobsbodymetrics.Models;
using bobsbodymetrics.Service;
using Microsoft.AspNetCore.Mvc;

namespace bobsbodymetrics.Controllers
{
    [ApiController]
    [Route("profile")]
    public class ProfileController(ProfileService profileService) : ControllerBase
    {
        private readonly ProfileService _profileService = profileService;

        [HttpGet("user/{username}")]
        public IActionResult GetPublicProfile(string username)
        {
            var profile = _profileService.GetPublicProfile(username);
            if (profile != null)
            {
                return Ok(profile);
            }
            return NotFound();
        }

        [HttpGet("user/private/{userId}")]
        public IActionResult GetPrivateProfile(string userId)
        {
            var profile = _profileService.GetPrivateProfile(userId);
            if (profile != null)
            {
                return Ok(profile);
            }
            return NotFound();
        }
        [HttpGet]
        public IActionResult GetAllProfiles()
        {
            var profiles = _profileService.GetAllProfiles();
            return Ok(profiles);
        }

        [HttpGet("{id}")]
        public IActionResult GetProfileById(int id)
        {
            var profile = _profileService.GetProfileById(id);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        [HttpPost]
        public IActionResult CreateProfile([FromBody] Profile profile)
        {
            if (profile == null)
            {
                return BadRequest();
            }

            _profileService.CreateProfile(profile);
            return CreatedAtAction(nameof(GetProfileById), new { id = profile.ProfileId }, profile);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProfile(int id, [FromBody] Profile profile)
        {
            if (profile == null || profile.ProfileId != id)
            {
                return BadRequest();
            }

            var existingProfile = _profileService.GetProfileById(id);
            if (existingProfile == null)
            {
                return NotFound();
            }

            _profileService.UpdateProfile(profile);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProfile(int id)
        {
            var profile = _profileService.GetProfileById(id);
            if (profile == null)
            {
                return NotFound();
            }

            _profileService.DeleteProfile(id);
            return NoContent();
        }
    }
}
