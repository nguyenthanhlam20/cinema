using Cinema.Models;

namespace Cinema.Services.Slots
{
    public interface ISlotService
    {
        Task<List<Slot>> GetSlots();
    }
}
