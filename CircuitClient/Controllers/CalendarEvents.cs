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
        return RedirectToAction("Index")
    }

}