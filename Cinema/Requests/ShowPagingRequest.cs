using Cinema.Models;

namespace Cinema.Requests
{
    public class ShowPagingRequest : PagingRequestBase<Show>
    {
        public string Title { get; set; } = string.Empty;
        public string Date {  get; set; } = string.Empty;
        public string Order { get; set; } = string.Empty;

    }
}
