using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using V2Props.File;

namespace V2Props.Services {

    public interface IFileStorageService {

        Task<IFile> SaveFileAsync(IFormFile formFile);
    }
}