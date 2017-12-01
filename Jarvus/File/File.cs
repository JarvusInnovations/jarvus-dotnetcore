namespace V2Props.File {

    public abstract class File : IFile {

        public File() {
        }

        public string RelativePath { get; set; }
        public string AbsoluteBase { get; set; }
        
        public abstract string PublicUri { get; set; }
    }
}