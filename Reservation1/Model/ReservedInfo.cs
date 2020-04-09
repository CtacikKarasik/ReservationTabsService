using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation1.Model
{
    public class ReservedInfo
    {
        public string NubmerPhone
        {
            get;
            set;
        }
        public DateTime StartDateTimeReserv
        { 
            get;
            set;
        }
        public DateTime FinishDateTimeReserv
        {
            get;
            set;
        }
        public string RegistrationName
        {
            get;
            set;
        }
        public string Comment
        {
            get;
            set;
        }
        public TableStatus ReservationStatus
        {
            get;
            set;
        }
    }
}
