using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CircuitClient.Models
{
    public class CalendarEvent
    {
        public int CalendarEventId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public static List<CalendarEvent> GetCalendarEvents()
        {
            var apiCallTask = ApiHelper.GetAll();
            var result = apiCallTask.Result;

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
            List<CalendarEvent> calendarEvent = JsonConvert.DeserializeObject<List<CalendarEvent>>(jsonResponse.ToString());

            return calendarEvent;
        }

        public static CalendarEvent GetDetails(int id)
        {
            var apiCallTask = ApiHelper.Get(id);
            var result = apiCallTask.Result;

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            CalendarEvent calendarEvent = JsonConvert.DeserializeObject<CalendarEvent>(jsonResponse.ToString());

            return calendarEvent;
        }

public static void Post(CalendarEvent calendarEvent)
{
    string jsonCalendarEvent = JsonConvert.SerializeObject(calendarEvent);
    ApiHelper.Post(jsonCalendarEvent);
}
    }
}