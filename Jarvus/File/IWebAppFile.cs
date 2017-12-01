namespace Jarvus.File {

    public abstract class IWebAppFile : IFile {
        
        /**
        
        For local storage, that should look like /images/upload/imagename.png
        
        For blob storage, it should look like /images/upload/imagename.png
        **/
        public string RelativePath { get; set; }
        
        public string AbsoluteBase { get; set; }
        
        string PublicUri { get; set; }
    }
}