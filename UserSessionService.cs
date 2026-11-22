namespace EventEase.Services
{
    public class UserSessionService
    {
        public string? CurrentUserName { get; private set; }
        public string? CurrentUserEmail { get; private set; }
        public List<int> RegisteredEventIds { get; } = new();

        public event Action? OnSessionChanged;

        public bool IsLoggedIn => !string.IsNullOrWhiteSpace(CurrentUserEmail);

        public void SetUserSession(string name, string email)
        {
            CurrentUserName = name;
            CurrentUserEmail = email;
            NotifyStateChanged();
        }

        public void RecordEventRegistration(int eventId)
        {
            if (!RegisteredEventIds.Contains(eventId))
            {
                RegisteredEventIds.Add(eventId);
                NotifyStateChanged();
            }
        }

        public void ClearSession()
        {
            CurrentUserName = null;
            CurrentUserEmail = null;
            RegisteredEventIds.Clear();
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnSessionChanged?.Invoke();
    }
}
