using System;
using System.Collections.Generic;

namespace Cinema.Models
{
    public partial class Show
    {
        public Show()
        {
            Bookings = new HashSet<Booking>();
        }

        public int ShowId { get; set; }
        public DateTime ShowDate { get; set; }
        public int SlotId { get; set; }
        public int FilmId { get; set; }
        public int RoomId { get; set; }
        public int? Status { get; set; }

        public virtual Film Film { get; set; } = null!;
        public virtual Room Room { get; set; } = null!;
        public virtual Slot Slot { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
