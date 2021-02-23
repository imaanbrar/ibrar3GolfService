using System;
using System.Collections.Generic;

namespace ibrar3GolfDataModel.Models
{
    public partial class User
    {
        public User()
        {
            Reservation = new HashSet<Reservation>();
            Scores = new HashSet<Scores>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string RoleCode { get; set; }
        public bool IsActive { get; set; }
        public double? HandicapScore { get; set; }
        public double TotalScore { get; set; }

        public virtual ICollection<Reservation> Reservation { get; set; }
        public virtual ICollection<Scores> Scores { get; set; }
    }
}
