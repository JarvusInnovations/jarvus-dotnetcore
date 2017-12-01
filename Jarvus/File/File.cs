namespace Jarvus.File {

    /**
        This class represents a file on any particular file system.

        Usage:

            var file = new File('/home/jsmiley/tmp/myawesomefile.txt');

            var file = new File {
                AbsoluteBase = '/home/jsmiley',
                RelativePath = 'tmp/myawesomefile.txt'
            };

            file.AbsolutePath would return '/home/jsmiley/tmp/myawesomefile.txt' in both cases.
     */
    public class File : IFile {

        public File() {
        }

        public File(string filename) {
            _AbsolutePath = filename;
        }

        protected string _AbsolutePath;

        public string AbsolutePath {

            get {
                if (_AbsolutePath != null) {
                    return _AbsolutePath;
                }
                else {
                    return string.Join("/", new string[] { AbsoluteBase, RelativePath });
                }
            }

            internal set {}
        }

        public string RelativePath { get; set; }

        public string AbsoluteBase { get; set; }
    }
}