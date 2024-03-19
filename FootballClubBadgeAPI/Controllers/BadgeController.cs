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
        public byte[] GetClubBadge([FromRoute] string team)
        {
            _imageStorageService.GetTeamBadgePng(team);
            return new byte[0];
        }
    }
}
