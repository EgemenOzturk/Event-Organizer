using EventOrganizer.Data.Base;
using EventOrganizer.Data.ViewModels;
using EventOrganizer.Models;
using System.Threading.Tasks;

namespace EventOrganizer.Data.Services
{
    public interface IEventsService:IEntityBaseRepository<Event>
    {
        Task<Event> GetEventByIdAsync(int id);
        Task AddNewEventAsync(NewEventVM data);
        Task UpdateEventAsync(NewEventVM data);
    }
}
