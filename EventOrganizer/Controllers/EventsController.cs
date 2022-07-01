
using EventOrganizer.Data.Services;
using EventOrganizer.Data.Static;
using EventOrganizer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EventOrganizer.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]

    public class EventsController : Controller
    {
        private readonly IEventsService _service;
        public EventsController(IEventsService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public  async Task<IActionResult> Index()
        {
            var allEvents = await _service.GetAllAsync();
            return View(allEvents.OrderBy(n => n.EndDate));
        }
        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allEvents = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allEvents.Where(n=> n.Name.IndexOf(searchString, 
                    StringComparison.OrdinalIgnoreCase) >= 0 ||
                    n.Description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                return View("Index", filteredResult);
            }
            return View("Index", allEvents);
        }

        //GET: Events/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var eventDetail = await _service.GetEventByIdAsync(id);
            return View(eventDetail);
        }

        //GET: Events/Create

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewEventVM Event)
        {
            if (!ModelState.IsValid)
            {
                return View(Event);
            }
            await _service.AddNewEventAsync(Event);
            return RedirectToAction(nameof(Index));
        }

        //GET: Events/Edit/1

        public async Task<IActionResult> Edit(int id)
        {   
            var eventDetails = await _service.GetEventByIdAsync(id);
            if (eventDetails == null) return View("NotFound");

            var response = new NewEventVM()
            {
                Id = eventDetails.Id,
                Name = eventDetails.Name,
                Description = eventDetails.Description,
                Price = eventDetails.Price,
                ImageURL = eventDetails.ImageURL,
                EventCategory = eventDetails.EventCategory,
                StartDate = eventDetails.StartDate,
                EndDate = eventDetails.EndDate,
                Capacity = eventDetails.Capacity
            };

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewEventVM Event)
        {
            if (id != Event.Id) return View("Not Found");

            if (!ModelState.IsValid)
            {
                return View(Event);
            }
            await _service.UpdateEventAsync(Event);
            return RedirectToAction(nameof(Index));
        }

        //GET: Events/Delete/1

        public async Task<IActionResult> Delete(int id)
        {
            var eventDetails = await _service.GetEventByIdAsync(id);
            if (eventDetails == null) return View("NotFound");

            var response = new NewEventVM()
            {
                Id = eventDetails.Id,
                Name = eventDetails.Name,
                Description = eventDetails.Description,
                Price = eventDetails.Price,
                ImageURL = eventDetails.ImageURL,
                EventCategory = eventDetails.EventCategory,
                StartDate = eventDetails.StartDate,
                EndDate = eventDetails.EndDate,
                Capacity = eventDetails.Capacity
            };

            return View(response);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventDetails = await _service.GetEventByIdAsync(id);
            if (eventDetails == null) return View("NotFound");

            await _service.DeleteEventAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
