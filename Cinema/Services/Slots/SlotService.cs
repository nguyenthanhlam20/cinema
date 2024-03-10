using Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.Slots
{
    public class SlotService : ISlotService
    {
        private readonly CinemaContext _context;

        public SlotService(CinemaContext context)
        {
            _context = context;
        }


        public async Task<List<Slot>> GetSlots()
        {
            try
            {
                var slots = await _context.Slots.ToListAsync();
                return slots;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.ToString()}");
            }
            return new List<Slot>();
        }
    }
}
