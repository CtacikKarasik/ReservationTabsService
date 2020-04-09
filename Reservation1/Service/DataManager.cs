using Newtonsoft.Json;
using Reservation1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation1.Service
{
    public class DataManager
    {
        private readonly FileLoader _fileLoader;

        public DataManager(FileLoader fileLoader)
        {
            _fileLoader = fileLoader;
        }

        public List<TableInfo> ReadReservedTablesList()
        {
            return JsonConvert.DeserializeObject<List<TableInfo>>(_fileLoader.Load());
        }

        public void WriteReservedTablesList(List<TableInfo> tablesInfo)
        {
            string json = JsonConvert.SerializeObject(tablesInfo);
            _fileLoader.Save(json);
        }
    }
}
