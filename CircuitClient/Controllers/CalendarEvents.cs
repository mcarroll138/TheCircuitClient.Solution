using Microsoft.AspNetCore.Mvc;
using CircuitClient.Models;
using System.Threading.Tasks;
using Newtonsoft.Json; // Import the Newtonsoft.Json namespace

namespace CircuitClient.Controllers
{
    public class CalendarEventsController : Controller
    {
        public async Task<IActionResult> Index(string searchTerm)
        {
            string filteredEventsJson = await ApiHelper.GetFilteredEvents(searchTerm);

            // Deserialize the JSON into a List<CalendarEvent>
            List<CalendarEvent> filteredEvents = JsonConvert.DeserializeObject<List<CalendarEvent>>(filteredEventsJson);

            // Return a view with the filtered events
            return View(filteredEvents);
        }


        public IActionResult Details(int id)
        {
            CalendarEvent calendarEvent = CalendarEvent.GetDetails(id);
            return View(calendarEvent);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CalendarEvent calendarEvent)
        {
            CalendarEvent.Post(calendarEvent);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            CalendarEvent calendarEvent = CalendarEvent.GetDetails(id);
            return View(calendarEvent);
        }
        //get calendar details?Get Details? Check Line 34 and 16
        [HttpPost]
        public ActionResult Edit(CalendarEvent calendarEvent)
        {
            CalendarEvent.Put(calendarEvent);
            return RedirectToAction("Details", new { id = calendarEvent.CalendarEventId });
        }

        public ActionResult Delete(int id)
        {
            CalendarEvent calendarEvent = CalendarEvent.GetDetails(id);
            return View(calendarEvent);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            CalendarEvent.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
