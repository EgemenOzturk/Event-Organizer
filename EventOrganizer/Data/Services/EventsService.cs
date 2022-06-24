using EventOrganizer.Data.Base;
using EventOrganizer.Data.ViewModels;
using EventOrganizer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EventOrganizer.Data.Services
{
    public class EventsService:EntityBaseRepository<Event>, IEventsService
    {   
        private readonly AppDbContext _context;
        public EventsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewEventAsync(NewEventVM data)
        {
            var newEvent = new Event()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                EventCategory = data.EventCategory,
                Capacity = data.Capacity
            };
            await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync();
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            return await _context.Events.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task UpdateEventAsync(NewEventVM data)
        {
            var dbEvent = await _context.Events.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbEvent != null)
            {
                dbEvent.Name = data.Name;
                dbEvent.Description = data.Description;
                dbEvent.Price = data.Price;
                dbEvent.ImageURL = data.ImageURL;
                dbEvent.StartDate = data.StartDate;
                dbEvent.EndDate = data.EndDate;
                dbEvent.EventCategory = data.EventCategory;
                dbEvent.Capacity = data.Capacity;
                await _context.SaveChangesAsync();
            }
            await _context.SaveChangesAsync();
        }
    }
}
