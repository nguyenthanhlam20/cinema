using System;
using System.Collections.Generic;

namespace Cinema.Models
{
    public partial class Country
    {
        public Country()
        {
            Films = new HashSet<Film>();
        }

        public string CountryCode { get; set; } = null!;
        public string? CountryName { get; set; }

        public virtual ICollection<Film> Films { get; set; }
    }
}
