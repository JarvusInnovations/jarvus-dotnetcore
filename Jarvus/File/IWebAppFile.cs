namespace Jarvus.File {

    public abstract class IWebAppFile : File
    {
        abstract public string PublicUri { get; set; }
    }
}