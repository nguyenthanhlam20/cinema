using Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.Rooms
{
    public class RoomService : IRoomService
    {
        private readonly CinemaContext _context;

        public RoomService(CinemaContext context)
        {
            _context = context;
        }
        public async Task<List<Room>> GetRooms()
        {
            try
            {
                var rooms= await _context.Rooms.ToListAsync();
                return rooms;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return new List<Room>();
        }
    }
}
