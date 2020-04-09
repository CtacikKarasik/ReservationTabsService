using System.IO;

namespace Reservation1.Service
{
    public class FileLoader
    {
        private readonly string _path;
        private string _listReservedTables;

        public FileLoader(string path)
        {
            _path = path;
        }

        public string Load()
        {
            return _listReservedTables ?? (_listReservedTables = File.ReadAllText(_path));
        }

        public void Save(string jsonText)
        {
            File.WriteAllText(_path, jsonText);
        }

    }
}
