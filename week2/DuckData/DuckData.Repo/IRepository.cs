using DuckData.Models;

namespace DuckData.Repo
{
    // Agreement/contract
    // terms - the things that both parties agree to
    // like a template to be filled and used to your specifications
    // "we" (the class that extends this interface) are agreeing to use all of the methods that are laid out in the interface
    public interface IRepository
    {
        void ReadAndWriteWithFile(string path);
        void StreamReaderReadLine(string path);
        void StreamReaderReadToEnd(string path);
        List<Duck> ReadDucksFromFile(string path);
        void SaveDuck(Duck myDuck, string path);

        void SaveAllDucks(List<Duck> duckList, string path);

        List<Duck> LoadAllDucks(string path);
    }
}