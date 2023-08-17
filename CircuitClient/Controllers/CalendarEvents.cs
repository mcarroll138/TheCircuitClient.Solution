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
}