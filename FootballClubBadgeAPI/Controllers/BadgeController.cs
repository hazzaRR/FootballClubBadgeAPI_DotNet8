using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubBadgeAPI.Controllers
{
    [Route("api/badge")]
    [ApiController]
    public class BadgeController : ControllerBase
    {

        [HttpGet("{team}")]
        public byte[] GetClubBadge([FromRoute] string team)
        {
            return new byte[0];
        }
    }
}
