using EventEase.Models;

namespace EventEase.Services
{
    public class AttendanceRecord
    {
        public int EventId { get; set; }
        public string AttendeeName { get; set; } = string.Empty;
        public string AttendeeEmail { get; set; } = string.Empty;
        public int Tickets { get; set; }
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
        public bool CheckedIn { get; set; }
    }

    public class AttendanceService
    {
        private readonly List<AttendanceRecord> _records = new();

        public event Action? OnAttendanceUpdated;

        public void RegisterAttendee(RegistrationModel registration)
        {
            _records.Add(new AttendanceRecord
            {
                EventId = registration.EventId,
                AttendeeName = registration.FullName,
                AttendeeEmail = registration.Email,
                Tickets = registration.Tickets,
                RegisteredAt = DateTime.UtcNow,
                CheckedIn = false
            });
            OnAttendanceUpdated?.Invoke();
        }

        public List<AttendanceRecord> GetAttendeesForEvent(int eventId)
        {
            return _records.Where(r => r.EventId == eventId).ToList();
        }

        public int GetTotalTicketsForEvent(int eventId)
        {
            return _records.Where(r => r.EventId == eventId).Sum(r => r.Tickets);
        }

        public void ToggleCheckIn(AttendanceRecord record)
        {
            record.CheckedIn = !record.CheckedIn;
            OnAttendanceUpdated?.Invoke();
        }
    }
}
