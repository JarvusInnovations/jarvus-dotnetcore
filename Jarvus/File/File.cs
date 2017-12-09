using System;

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

        private string _AbsolutePath;

        public string AbsolutePath {

            get {
                if (_AbsolutePath != null) {
                    return _AbsolutePath;
                }
                else {
                    return string.Join("/", new string[] { AbsoluteBase, RelativePath });
                }
            }

            set {
                _AbsolutePath = value;
            }
        }

        public string RelativePath { get; set; }

        public string AbsoluteBase { get; set; }

        public string GetFileContentAsString() {
            var lines = System.IO.File.ReadAllLines(AbsolutePath);
            return String.Join("\n", lines);
        }
    }
}