using FootballClubBadgeAPI.Interfaces;

namespace FootballClubBadgeAPI.Services
{
    public class LocalImageStorageService : IImageStorageService

    {

        private readonly IWebHostEnvironment _env;

        public LocalImageStorageService(IWebHostEnvironment env)
        {
            _env = env;
        }
        public Task<byte[]> GetTeamBadgePng(string team)
        {

            throw new NotImplementedException();
        }
    }
}
