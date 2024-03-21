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
                blobs.Add(blobItem.Name);
            }

            return blobs.ToArray();
        }

        public byte[]? GetTeamBadgePng(string team)
        {
            throw new NotImplementedException();
        }
    }
}
