namespace Cinema.Responses
{
    public class BookingHistory
    {
        public int BookingId {  get; set; }
        public string Seat { get; set; } = string.Empty;
        public string Film { get; set; } = string.Empty;
        public DateTime date { get; set; } 
    }
}
