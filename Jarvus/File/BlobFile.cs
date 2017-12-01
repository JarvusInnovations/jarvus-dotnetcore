namespace Jarvus.File {

    public class BlobFile : IWebAppFile
    {
        public string ContainerName { get; set; }

        public string StorageAccountName { get; set; }
        public string PublicUri
        {
            get {
                var absoluteBase = AbsoluteBase;

                // if it's got an ending forward slash, remove it
                if (absoluteBase.EndsWith("/")) {
                    absoluteBase = absoluteBase.Remove(absoluteBase.Length - 1);
                }

                var seperator = "";

                if (!RelativePath.StartsWith("/")) {
                    seperator = "/";
                }

                var publicUri = absoluteBase + seperator + RelativePath;

                return publicUri;
            }

            set {}
        }
    }
}