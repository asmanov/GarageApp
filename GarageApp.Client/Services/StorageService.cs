 using System.Diagnostics;
using MudBlazor;
using Supabase.Storage.Interfaces;

namespace GarageApp.Client.Services
{
    public class StorageService
    {
        private readonly Supabase.Client _client;
        private readonly ILogger<DatabaseService> _logger;
        private readonly IDialogService _dialogService;
        private readonly IStorageClient<Supabase.Storage.Bucket, Supabase.Storage.FileObject> _storage;

        public StorageService(
            Supabase.Client client,
            ILogger<DatabaseService> logger,
            IDialogService dialogService
        )
        {
            logger.LogInformation("------------------- CONSTRUCTOR -------------------");
            _client = client;
            _logger = logger;
            _dialogService = dialogService;

            _storage = client.Storage;
        }

        public async Task<string> UploadFile(String bucketName, Stream streamData, String fileName, string registrationNomber)
        {
            var bucket = _storage.From(bucketName);

            var bytesData = await StreamToBytesAsync(streamData);

            var fileExtension = fileName.Split(".").Last();

            var saveName = registrationNomber;

            saveName = saveName.Replace("/", "_").Replace(" ", "_").Replace(":", "_");
            saveName = saveName + "." + fileExtension;

            return await bucket.Upload(bytesData, saveName);
        }

        public async Task<byte[]> StreamToBytesAsync(Stream streamData)
        {
            byte[] bytes;

            using var memoryStream = new MemoryStream();
            await streamData.CopyToAsync(memoryStream);
            bytes = memoryStream.ToArray();

            return bytes;
        }

        public async Task<List<Supabase.Storage.FileObject>?> GetFilesFromBucket(string bucketName)
        {
            return await _storage.From(bucketName).List();
        }

        public Task<byte[]> DownloadFile(string bucketName, string fileName)
        {
            var bucket = _storage.From(bucketName);
            return bucket.Download(fileName, (_, f) => Debug.WriteLine($"Download Progress: {f}%"));
        }

        public Task<string> GetImageUrl(string bucketName, string fileName)
        {
            var bucket = _storage.From(bucketName);
            return bucket.CreateSignedUrl(fileName, 60);
        }
    }
}
