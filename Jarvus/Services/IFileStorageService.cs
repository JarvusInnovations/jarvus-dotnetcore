using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Jarvus.File;
using System.Collections.Generic;

namespace Jarvus.Services {

    public interface IFileStorageService {

        Task<IEnumerable<Jarvus.File.IWebAppFile>> SaveFileAsync(IFormFile formFile, string SettingsName);
    }
}