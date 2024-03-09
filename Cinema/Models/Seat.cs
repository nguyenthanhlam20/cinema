using System;
using System.Collections.Generic;

namespace Cinema.Models
{
    public partial class Seat
    {
        public Seat()
        {
            Bookings = new HashSet<Booking>();
        }

        public int SeatId { get; set; }
        public string SeatName { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
