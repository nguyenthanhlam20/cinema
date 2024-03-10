using Cinema.Models;

namespace Cinema.Services.Rooms
{
    public interface IRoomService
    {
        Task<List<Room>> GetRooms();
    }
}
