using FootballClubBadgeAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubBadgeAPI.Controllers
{
    [Route("api/badge")]
    [ApiController]
    public class BadgeController : ControllerBase
    {

        private readonly IImageStorageService _imageStorageService;

        public BadgeController(IImageStorageService imageStorageService)
        {
            _imageStorageService = imageStorageService;
        }

        [HttpGet("{team}")]
        public async Task<IActionResult> GetClubBadge([FromRoute] string team)
        {
            var clubBadge = await _imageStorageService.GetTeamBadgePng(team);

            if (clubBadge == null)
            {
                return NotFound();
            }
            return Ok(clubBadge);
        }
    }
}
