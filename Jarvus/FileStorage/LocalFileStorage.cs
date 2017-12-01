using Microsoft.AspNetCore.Hosting;

namespace V2Props.FileStorage {

    public class LocalFileStorage : IFileStorage
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public LocalFileStorage(IHostingEnvironment hostingEnvironment) {
            _hostingEnvironment = hostingEnvironment;
        }

        public string BasePath() {
            return "";
        }

        public string RelativePath() {
            return "";
        }
    }
}