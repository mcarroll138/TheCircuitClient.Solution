using System.Threading.Tasks;
using RestSharp;

namespace CircuitClient.Models
{
    public class ApiHelper
    {
        public static async Task<string> GetAll()
        {
            RestClient client = new RestClient("http://localhost:5000/");
            RestRequest request = new RestRequest($"api/calendarEvents", Method.Get);
            RestResponse response = await client.GetAsync(request);
            return response.Content;
        }
        public static async Task<string> Get(int id)
        {
            RestClient client = new RestClient("http://localhost:5000/");
            RestRequest request = new RestRequest($"api/calendarEvents/{id}", Method.Get);
            RestResponse response = await client.GetAsync(request);
            return response.Content;
        }
        public static async void Post(string newCalendarEvent)
        {
            RestClient client = new RestClient("http://localhost:5000/");
            RestRequest request = new RestRequest($"api/calendarevents", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(newCalendarEvent);
            await client.PostAsync(request);
        }
        public static async void Put(int id, string newCalendarEvent)
        {
            RestClient client = new RestClient("http://localhost:5000/");
            RestRequest request = new RestRequest($"api/calendarevents/{id}", Method.Put);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(newCalendarEvent);
            await client.PutAsync(request);
        }

        public static async void Delete(int id)
        {
            RestClient client = new RestClient("http://localhost:5000/");
            RestRequest request = new RestRequest($"api/calendarevents/{id}", Method.Delete);
            request.AddHeader("Content-Type", "application/json");
            await client.DeleteAsync(request);
        }
    }
}