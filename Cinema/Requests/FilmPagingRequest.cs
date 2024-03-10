using Cinema.Models;

namespace Cinema.Requests
{
    public class FilmPagingRequest : PagingRequestBase<Film>
    {
        public string Title { get; set; } = string.Empty;

        public string Date { get; set; } = string.Empty;

        public int GenreId { get; set; }

        public string Country { get; set; } = string.Empty;

        public string Order { get; set; } = string.Empty;
    }
}
