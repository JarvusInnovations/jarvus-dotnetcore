using System;

namespace Jarvus.File {

    public class LocalFile : IWebAppFile
    {
        public string UriBase { get; set; }

        public LocalFile()
        {
        }

        public string PublicUri
        {
            get
            {
                return RelativePath;
            }

            set {}
         
         }
    }
}