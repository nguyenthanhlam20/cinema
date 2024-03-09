using System;
using System.Collections.Generic;

namespace Cinema.Models
{
    public partial class Film
    {
        public Film()
        {
            Shows = new HashSet<Show>();
        }

        public int FilmId { get; set; }
        public int GenreId { get; set; }
        public string Title { get; set; } = null!;
        public string CountryCode { get; set; } = null!;
        public string? Img { get; set; }
        public DateTime? Premiere { get; set; }
        public string? Actor { get; set; }
        public string? Author { get; set; }
        public int? Time { get; set; }
        public string? ImagesSlide { get; set; }
        public string? Description { get; set; }
        public bool? Status { get; set; }

        public virtual Country CountryCodeNavigation { get; set; } = null!;
        public virtual Genre Genre { get; set; } = null!;
        public virtual ICollection<Show> Shows { get; set; }
    }
}
