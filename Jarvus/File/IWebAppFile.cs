namespace Jarvus.File {

    public abstract class IWebAppFile : File
    {
        
        abstract public string PublicUri { get; set; }

        // we don't want to allow access to the vagueness of absolute path
        public string AbsolutePath => PublicUri;
    }
}