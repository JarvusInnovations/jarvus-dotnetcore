using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Jarvus.File;

namespace Jarvus.Services {

    public interface IFileStorageService {

        Task<IFile> SaveFileAsync(IFormFile formFile);
    }
}