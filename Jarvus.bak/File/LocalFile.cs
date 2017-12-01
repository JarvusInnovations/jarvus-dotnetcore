using System;

namespace V2Props.File {

    public class LocalFile : File
    {
        public string UriBase { get; set; }

        public LocalFile()
        {
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