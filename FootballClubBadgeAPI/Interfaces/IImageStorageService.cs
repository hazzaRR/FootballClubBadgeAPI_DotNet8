namespace FootballClubBadgeAPI.Interfaces
{
    public interface IImageStorageService
    {

        public FileStream? GetTeamBadgePng(string team);


        public string[] GetTeamBadgeFilenames();
    }
}
