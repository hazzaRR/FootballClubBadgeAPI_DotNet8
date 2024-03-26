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

        public string?[] GetTeamBadgeFilenamesAsync()
        {

            string assetsPath = Path.Combine(_rootPath, "Assets", "Images", "Badges");
            string[] fileArray = Directory.GetFiles(assetsPath, "*.png");

            //string[] teamNames1 = fileArray.Select(file => Path.GetFileName(file).Replace(".png", "")).ToArray(); 
            string?[] teamNames = fileArray.Select(Path.GetFileNameWithoutExtension).ToArray();

            return teamNames;
        }

        public Task<byte[]> GetTeamBadgePng(string team)
        {
            Console.WriteLine(_rootPath);
            string assetsPath = Path.Combine(_rootPath, "Assets", "Images", "Badges");

            string imagePath = Path.Combine(assetsPath, $"{team}.png");

            try
            {
                byte[] imageFile = File.ReadAllBytes(imagePath);

                return Task.FromResult(imageFile);

            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }
    }
}
