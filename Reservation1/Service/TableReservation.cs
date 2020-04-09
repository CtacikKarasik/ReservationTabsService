using Reservation1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation1.Service
{
    public class TableReservation
    {
        private readonly int _maxCountTable;
        private readonly int _countTableisPS4;
        private readonly DataManager _dataManager;
        private List<TableInfo> _tableInfoList;
        public TableReservation(DataManager dataManager, int maxCountTable, int countTableisPS4)
        {
            _maxCountTable = maxCountTable;
            _countTableisPS4 = countTableisPS4;
            _dataManager = dataManager;
            CreateListTable(_maxCountTable, _countTableisPS4);
        }
        public List<TableInfo> GetListInfoTables()
        {
            return _tableInfoList;
        }

        public TableInfo GetInfoTable(int idTable)
        {
            if (idTable < 0 || idTable > _maxCountTable)
            {
                return null;
            }
            return _tableInfoList.Where(t => t.NumberTable == idTable).First();   
        }

        public bool AddReservedTable(TableInfo tableInfo)
        {
            if (isFreeTable(tableInfo))
            {
                var reservedinfo = tableInfo.ReservedInfoList.First();
                _tableInfoList.Where(t => t.NumberTable == tableInfo.NumberTable).First().ReservedInfoList.Add(reservedinfo);

                _dataManager.WriteReservedTablesList(_tableInfoList);

                return true;
            }
            return false;
        }

        public void RemoveReservedTable(int idTable, string NumberPhone)
        {
            foreach (var table in _tableInfoList)
            {
                if (table.NumberTable == idTable)
                {
                    foreach (var reserved in table.ReservedInfoList)
                    {
                        if (reserved.NubmerPhone == NumberPhone)
                        {
                            table.ReservedInfoList.Remove(reserved);
                        }
                    }
                }
            }
        }

        private List<TableInfo> CreateListTable(int maxCountTable, int countTableisPS4)
        {
            _tableInfoList = new List<TableInfo>();

            for (int i = 1; i <= countTableisPS4; i++)
            {
                _tableInfoList.Add(new TableInfo { NumberTable = i, IsPS4 = true, ReservedInfoList = new List<ReservedInfo>() });
            }
            for (int i = countTableisPS4 +1; i <= maxCountTable; i++)
            {
                _tableInfoList.Add(new TableInfo { NumberTable = i, IsPS4 = false, ReservedInfoList = new List<ReservedInfo>() });
            }

            _dataManager.WriteReservedTablesList(_tableInfoList);

            return _tableInfoList;
        }

        private bool isFreeTable(TableInfo tableInfo)
        {
            foreach (var table in _tableInfoList)
            {
                if (table.NumberTable == tableInfo.NumberTable)
                {
                    if (table.ReservedInfoList == null)
                    {
                        return true;
                    }
                    if (!isСrossDateReserved(table.ReservedInfoList, tableInfo.ReservedInfoList))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool isСrossDateReserved(List<ReservedInfo> ReservedInfo, List<ReservedInfo> newReservedInfo)
        {
            foreach (var reserved in ReservedInfo)
            {
                foreach (var newReserved in newReservedInfo)
                {
                    if ((newReserved.StartDateTimeReserv >= reserved.StartDateTimeReserv && newReserved.StartDateTimeReserv <= reserved.FinishDateTimeReserv) ||
                        (newReserved.FinishDateTimeReserv >= reserved.StartDateTimeReserv && newReserved.FinishDateTimeReserv <= reserved.FinishDateTimeReserv))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
