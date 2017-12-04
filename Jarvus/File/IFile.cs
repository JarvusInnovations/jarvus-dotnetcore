namespace Jarvus.File {

    public interface IFile {
        
        string RelativePath { get; set; }

        string AbsoluteBase { get; set; }

        string AbsolutePath { get; }
    }
}