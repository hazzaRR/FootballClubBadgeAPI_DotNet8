namespace FootballClubBadgeAPI.Interfaces
{
    public interface IImageStorageService
    {

        public Task<byte[]> GetTeamBadgePng(string team);
    }
}
