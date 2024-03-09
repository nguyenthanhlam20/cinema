using System;
using System.Collections.Generic;

namespace Cinema.Models
{
    public partial class Booking
    {
        public Booking()
        {
            Seats = new HashSet<Seat>();
        }

        public int BookingId { get; set; }
        public int ShowId { get; set; }
        public int UserId { get; set; }

        public virtual Show Show { get; set; } = null!;
        public virtual User User { get; set; } = null!;

        public virtual ICollection<Seat> Seats { get; set; }
    }
}
