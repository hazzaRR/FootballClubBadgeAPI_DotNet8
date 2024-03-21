using Azure.Storage.Blobs;
using FootballClubBadgeAPI.Interfaces;

namespace FootballClubBadgeAPI.Services
{
    public class AzureImageStorageService : IImageStorageService
    {

        BlobServiceClient _blobServiceClient;

        public AzureImageStorageService(BlobServiceClient blobServiceClient) 
        {
            _blobServiceClient = blobServiceClient;

        }

        public string?[] GetTeamBadgeFilenames()
        {
            throw new NotImplementedException();
        }

        public byte[]? GetTeamBadgePng(string team)
        {
            throw new NotImplementedException();
        }
    }
}
