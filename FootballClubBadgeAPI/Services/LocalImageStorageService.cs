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

        public string[] GetTeamBadgeFilenames()
        {

            string assetsPath = Path.Combine(_rootPath, "Assets", "Images", "Badges");
            string[] fileArray = Directory.GetFiles(assetsPath, "*.png");


            foreach (string file in fileArray)
            {
                Console.WriteLine(Path.GetFileName(file));
            }

            string[] teamNames = fileArray.Select(file => Path.GetFileName(file).Replace(".png", "")).ToArray(); 


            return teamNames;
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
