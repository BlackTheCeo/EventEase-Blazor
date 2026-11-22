using EventEase.Models;

namespace EventEase.Services
{
    public class EventService
    {
        private readonly List<Event> _events = new()
        {
            new Event
            {
                Id = 1,
                Title = "Blazor & .NET 8 Architecture Summit",
                Date = DateTime.Today.AddDays(14),
                Location = "San Francisco, CA — Moscone Center",
                Description = "Deep dive into interactive server and WebAssembly rendering patterns with Microsoft engineers.",
                Capacity = 250
            },
            new Event
            {
                Id = 2,
                Title = "AI-Assisted Development Workshop",
                Date = DateTime.Today.AddDays(21),
                Location = "Seattle, WA — Convention Hub",
                Description = "Hands-on labs covering Microsoft Copilot workflows for rapid C# and Razor component scaffolding.",
                Capacity = 120
            },
            new Event
            {
                Id = 3,
                Title = "Cloud-Native Microservices Meetup",
                Date = DateTime.Today.AddDays(30),
                Location = "Austin, TX — Tech Commons",
                Description = "Networking and live demos on containerizing ASP.NET Core applications.",
                Capacity = 80
            }
        };

        public List<Event> GetAllEvents() => _events;

        public Event? GetEventById(int id) => _events.FirstOrDefault(e => e.Id == id);
    }
}
