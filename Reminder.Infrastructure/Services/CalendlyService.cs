using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Reminder.Domain;
using Reminder.Domain.Interfaces;
using System.Net.Http.Headers;

namespace Reminder.Infrastructure.Services
{
    public class CalendlyService : ICalendlyService
    {
        private readonly string _token;
        private readonly string _baseUrl;
        private readonly string _user;
        private readonly HttpClient _client;
        
        public CalendlyService(IConfiguration configuration, HttpClient httpClient)
        {
            _client = httpClient;
            _token = configuration["CalendlySettings:ApiToken"];
            _baseUrl = configuration["CalendlySettings:BaseUrl"];
            _user = configuration["CalendlySettings:User"];
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsAsync()
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            string eventsUrl = $"{_baseUrl}/scheduled_events?user={_user}";
            HttpResponseMessage response = await _client.GetAsync(eventsUrl);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(result);

                foreach (var ev in json["collection"])
                {
                    string eventId = ev["uri"].ToString().Split('/').Last();
                    string eventName = ev["name"].ToString();
                    string startTime = ev["start_time"].ToString();

                    Console.WriteLine($"Événements : {eventName} (Début : {startTime}");
                    var invitees = await GetInviteesAsync(eventId);
                }

                return new[] { new Appointment() };
            }
            else
            {
                Console.WriteLine($"Erreur lors de la récupération des événements: {response.StatusCode}");
                return Enumerable.Empty<Appointment>();
            }
        }

        private async Task<List<string>> GetInviteesAsync(string eventId)
        {
            var inviteesList = new List<string>();

            string inviteesUrl = $"{_baseUrl}/scheduled_events/{eventId}/invitees";
            HttpResponseMessage response = await _client.GetAsync(inviteesUrl);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(result);

                foreach (var invitee in json["collection"])
                {
                    string inviteeName = invitee["name"].ToString();
                    string inviteeEmail = invitee["email"].ToString();

                    Console.WriteLine($"  Participant : {inviteeName} (Email : {inviteeEmail})");
                    inviteesList.Add(inviteeName);
                }
            }
            else
            {
                Console.WriteLine($"Erreur lors de la récupération des participants: {response.StatusCode}");
            }

            return inviteesList;
        }
    }
}
