using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Jarvus.File;

namespace Jarvus.Services {

    public interface IFileStorageService {

        Task<Jarvus.File.IWebAppFile> SaveFileAsync(IFormFile formFile, string SettingsName);
    }
}