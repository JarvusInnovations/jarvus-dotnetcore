namespace V2Props.File {

    public interface IFile {
        
        /**
        
        For local storage, that should look like /images/upload/imagename.png
        
        For blob storage, it should look like /images/upload/imagename.png
        **/
        string RelativePath { get; set; }

        /**
        
        **/
        string AbsoluteBase { get; set; }

        string PublicUri { get; set; }
    }
}