using System;
using System.Collections.Generic;

namespace ibrar3GolfDataModel.Models
{
    public partial class Scores
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DatePlayed { get; set; }
        public double Hole18 { get; set; }
        public double Hole17 { get; set; }
        public double Hole16 { get; set; }
        public double Hole15 { get; set; }
        public double Hole14 { get; set; }
        public double Hole13 { get; set; }
        public double Hole12 { get; set; }
        public double Hole11 { get; set; }
        public double Hole10 { get; set; }
        public double Hole9 { get; set; }
        public double Hole8 { get; set; }
        public double Hole7 { get; set; }
        public double Hole6 { get; set; }
        public double Hole5 { get; set; }
        public double Hole4 { get; set; }
        public double Hole3 { get; set; }
        public double Hole2 { get; set; }
        public double Hole1 { get; set; }

        public virtual User User { get; set; }
    }
}
