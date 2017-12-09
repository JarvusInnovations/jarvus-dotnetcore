using System;

namespace Jarvus.File {

    public class LocalFile : IWebAppFile
    {
        public LocalFile() : base() {}
        
        public LocalFile(string absolutePath)
        {
            RelativePath = absolutePath;
        }

        public override string PublicUri
        {
            get
            {
                return RelativePath;
            }

            set {}
         }
    }
}