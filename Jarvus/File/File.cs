namespace Jarvus.File {

    public class File : IFile {

        public File() {
        }

        public string RelativePath { get; set; }
        public string AbsoluteBase { get; set; }
    }
}