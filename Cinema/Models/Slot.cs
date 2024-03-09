using System;
using System.Collections.Generic;

namespace Cinema.Models
{
    public partial class Slot
    {
        public Slot()
        {
            Shows = new HashSet<Show>();
        }

        public int SlotId { get; set; }
        public string Time { get; set; } = null!;

        public virtual ICollection<Show> Shows { get; set; }
    }
}
