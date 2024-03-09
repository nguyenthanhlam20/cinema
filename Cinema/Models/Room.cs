using System;
using System.Collections.Generic;

namespace Cinema.Models
{
    public partial class Room
    {
        public Room()
        {
            Shows = new HashSet<Show>();
        }

        public int RoomId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Show> Shows { get; set; }
    }
}
