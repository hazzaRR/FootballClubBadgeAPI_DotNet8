using FootballClubBadgeAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

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

        [HttpGet("teams")]
        public IActionResult GetTeams()
        {
            var teams = _imageStorageService.GetTeamBadgeFilenamesAsync();

            if (teams == null)
            {
                return NotFound();
            }
            return Ok(teams);
        }

        [HttpGet("{team}")]
        public IActionResult GetClubBadge([FromRoute] string team)
        {
            var clubBadge = _imageStorageService.GetTeamBadgePng(team);

            if (clubBadge == null)
            {
                return NotFound($"A file for the team name: {team} does not exist");
            }
            return File(clubBadge, "image/png");
        }

    }
}
