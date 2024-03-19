using FootballClubBadgeAPI.Interfaces;

namespace FootballClubBadgeAPI.Services
{
    public class LocalImageStorageService : IImageStorageService

    {

        private readonly string _rootPath;

        public LocalImageStorageService(IWebHostEnvironment env)
        {
            _rootPath = env.ContentRootPath;
        }
        public FileStream? GetTeamBadgePng(string team)
        {
            Console.WriteLine(_rootPath);
            string assetsPath = Path.Combine(_rootPath, "Assets", "Images", "Badges");
            string imagePath = Path.Combine(assetsPath, $"{team}.png");


            try
            {
                FileStream imageFile = File.OpenRead(imagePath);

                return imageFile;

            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }


      

        }
    }
}
