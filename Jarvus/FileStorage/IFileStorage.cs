namespace Jarvus.FileStorage {

    public interface IFileStorage {

        string BasePath();

        string RelativePath();
    }
}