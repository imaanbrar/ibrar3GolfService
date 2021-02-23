using System;
using System.Collections.Generic;

namespace ibrar3GolfDataModel.Models
{
    public partial class Reservation
    {
        public int Id { get; set; }
        public string TypeCode { get; set; }
        public int UserId { get; set; }
        public int? Players { get; set; }
        public bool IsApproved { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string RecurringRule { get; set; }
        public string RecurringDay { get; set; }
        public string Notes { get; set; }

        public virtual User User { get; set; }
    }
}
