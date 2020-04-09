using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation1.Model
{
    public class TableInfo
    {
        private List<ReservedInfo> _reservedInfoList;
        public int NumberTable
        {
            get;
            set;
        }
        public bool IsPS4
        {
            get;
            set;
        }
        public List<ReservedInfo> ReservedInfoList 
        { 
            get => _reservedInfoList; 
            set => _reservedInfoList = value; 
        }
    }
}
