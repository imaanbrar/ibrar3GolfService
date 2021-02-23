using System;
using System.Collections.Generic;
using System.Text;

namespace ibrar3GolfDataModel.ViewModels
{
    public class ReservationView
    {
        public int Id { get; set; }
        public string TypeCode { get; set; }
        public int UserId { get; set; }
        public int? Players { get; set; }
        public bool IsApproved { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public string RecurringRule { get; set; }
        public string RecurringDay { get; set; }
        public string UserName { get; set; }
        public string ReservationType { get; set; }

    }
}
