using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using FootballClubBadgeAPI.Interfaces;

namespace FootballClubBadgeAPI.Services
{
    public class AzureImageStorageService : IImageStorageService
    {
        private const string ContainerName = "football-badges";
        private readonly BlobServiceClient _blobServiceClient;
        private readonly BlobContainerClient _containerClient;

        public AzureImageStorageService(BlobServiceClient blobServiceClient) 
        {
            _blobServiceClient = blobServiceClient;
            _containerClient = _blobServiceClient.GetBlobContainerClient(ContainerName);
            _containerClient.CreateIfNotExists();

        }

        public string?[] GetTeamBadgeFilenamesAsync()

        {
            var blobs = new List<string>();
            foreach (BlobItem blobItem in _containerClient.GetBlobs())
            {
                blobs.Add(Path.GetFileNameWithoutExtension(blobItem.Name));
            }

            return blobs.ToArray();
        }

        public async Task<byte[]> GetTeamBadgePng(string team)
        {
            BlobClient blobClient = _containerClient.GetBlobClient($"{team}.png");

                try
                {
                    BlobDownloadResult downloadResult = await blobClient.DownloadContentAsync();
                    byte[] blobContents = downloadResult.Content.ToArray();
                    return blobContents;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }

        }
    }
}
