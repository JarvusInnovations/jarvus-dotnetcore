using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Jarvus.File;
using Jarvus.FileStorage;
using Jarvus.Settings;

namespace Jarvus.Services {

    public class FileStorageService : Jarvus.Services.IFileStorageService {
        private readonly ILogger<FileStorageService> _logger;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IOptions<AzureStorageSettings> _azureStorageSettings;

        public FileStorageService(
                IHostingEnvironment hostingEnvironment,
                ILogger<FileStorageService> logger,
                IOptions<AzureStorageSettings> azureStorageSettings
            )
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _azureStorageSettings = azureStorageSettings;
        }

        public async Task<Jarvus.File.IWebAppFile> SaveFileAsync(IFormFile formFile, string SettingsName)
        {
            Jarvus.File.IWebAppFile File = await SaveToLocalContentAsync(formFile);

            var storageSettings = _azureStorageSettings.Value.GetBlobStorageSettingsByName(SettingsName);

            if (storageSettings != null)
            {
                _logger.LogWarning("azure storage settings are valid; attempting to save there");
                Jarvus.File.BlobFile BlobFile = await SaveToAzureStorageAsync(File, storageSettings);

                var localFile = File.AbsoluteBase+"/"+BlobFile.RelativePath;
                //_logger.LogDebug($"deleting local file {localFile}");
                //System.IO.File.Delete(localFile);
            }
            else
            {
                _logger.LogWarning("azure storage settings not set; will not upload file to blob storage");
            }
            
            return File;
        }

        private async Task<BlobFile> SaveToAzureStorageAsync(
                Jarvus.File.IWebAppFile File,
                AzureBlobStorageSettings storageSettings
            )
        {
            String StorageAccountName = storageSettings.StorageAccountName;
            String FullImagesContainerName = storageSettings.ContainerName;

            string relativePath = File.RelativePath;
            if (relativePath.StartsWith("/")) {
                relativePath = relativePath.Substring(1, relativePath.Length-1);
            }

            String BlobName = relativePath;

            _logger.LogDebug($"uploading to storage account name {StorageAccountName}; container named {FullImagesContainerName}; blob-name {BlobName}");

            CloudStorageAccount storageAccount = new CloudStorageAccount(
                new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
                        StorageAccountName,
                        storageSettings.AccessKey
                    ),
                true
            );
            
            // Create a blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Get a reference to a container named "my-new-container."
            CloudBlobContainer container = blobClient.GetContainerReference(
                                        FullImagesContainerName);

            // If "mycontainer" doesn't exist, create it.
            await container.CreateIfNotExistsAsync();

            // Get a reference to a blob named "myblob".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(BlobName);

            // Create or overwrite the "myblob" blob with the contents of a local file
            // named "myfile".
            using (var fileStream = System.IO.File.OpenRead(File.AbsoluteBase + "/" + File.RelativePath))
            {
                await blockBlob.UploadFromStreamAsync(fileStream);
            }

            _logger.LogDebug("upload finished");

            return new BlobFile {
                    AbsoluteBase = storageSettings.BaseUri,
                    RelativePath = File.RelativePath,
                    StorageAccountName = StorageAccountName,
                    ContainerName = FullImagesContainerName
                };
        }

        private async Task<Jarvus.File.IWebAppFile> SaveToLocalContentAsync(IFormFile formFile)
        {
            string tempFilePath = Path.GetTempFileName();

            _logger.LogInformation($"saving IFormFile locally to temp directory {tempFilePath}");

            using (var stream = new FileStream(tempFilePath, FileMode.Create))
            {
                // saves form upload file to the temp file
                await formFile.CopyToAsync(stream);
            } 

            string FileExtension = GetFileExtension(formFile);

            string uploadDirectoryPath = _hostingEnvironment.ContentRootPath + "/wwwroot";

            string relativeFilePath = "/uploads/" + Path.GetFileName(tempFilePath) + FileExtension;

            string contentFilePath = uploadDirectoryPath + relativeFilePath;

            System.IO.File.Move(tempFilePath, contentFilePath);

            return new Jarvus.File.LocalFile {
                    AbsoluteBase = uploadDirectoryPath,
                    RelativePath = relativeFilePath
                };
        }

        private static string GetFileExtension(IFormFile formFile)
        {
            // now move the file from the temp directory to the content directory
            string FileName = formFile.FileName;

            // will contain leading .
            string FileExtension = Path.GetExtension(FileName);
            return FileExtension;
        }
    }
}