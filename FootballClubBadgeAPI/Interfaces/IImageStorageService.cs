namespace FootballClubBadgeAPI.Interfaces
{
    public interface IImageStorageService
    {

        public byte[]? GetTeamBadgePng(string team);


        public string?[] GetTeamBadgeFilenames();
    }
}
