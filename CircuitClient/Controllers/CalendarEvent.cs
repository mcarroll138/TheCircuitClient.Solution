using Microsoft.AspNetCore.Mvc;
using CircuitClient.Models;

namespace CircuitClient.Controllers;

public class CalendarEventsController : Controller
{
    public IActionResult Index()
    {
        List<CalendarEvent> calendarEvent = CalendarEvent.GetCalendarEvents();
        return View(calendarEvent);
    }
}