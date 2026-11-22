# EventEase — Blazor Event Management Application

**EventEase** is a Blazor Web App (.NET 8) built for managing corporate and social events, complete with live two-way data binding, validated registration forms, scoped user session state, and a real-time attendance tracker.

---

## Project Architecture & Features

* **`Models/Event.cs` & `Models/RegistrationModel.cs`**: Strongly typed data models decorated with `System.ComponentModel.DataAnnotations` (`[Required]`, `[EmailAddress]`, `[StringLength]`, `[Range]`).
* **`Components/EventCard.razor`**: Reusable component rendering event details with live two-way data binding (`@bind`) for inline editing and dynamic navigation links.
* **`Components/Pages/Home.razor`**: Event catalog featuring real-time search filtering and `@key` directives for optimized rendering performance.
* **`Components/Pages/EventDetails.razor`**: Parameterized route (`/events/{EventId:int}`) with null-safe handling for invalid event IDs.
* **`Components/Pages/Register.razor`**: Interactive `<EditForm>` using `<DataAnnotationsValidator />`, `<ValidationSummary />`, and `<ValidationMessage />` to prevent invalid submissions.
* **`Components/Pages/AttendanceTracker.razor`**: Real-time attendance dashboard powered by `AttendanceService` allowing organizers to track ticket counts and check in guests.
* **`Services/UserSessionService.cs` & `Services/AttendanceService.cs`**: Scoped state management services persisting user session data and event registrations across views.
* **`Components/Routes.razor`**: Configured `<Router>` with `<Found>` and `<NotFound>` templates to gracefully handle invalid routes.

---

## How Microsoft Copilot Assisted in Development

1. **Foundational Components (Activity 1):**
   * Prompted Copilot to scaffold the `Event` model and `EventCard.razor` component with clean Razor syntax and Bootstrap/CSS styling.
   * Used Copilot suggestions to implement two-way data binding (`@bind` and `@bind:event="oninput"`) for real-time updates in both the event card inline editor and the search filter.

2. **Routing & Navigation (Activity 1 & 2):**
   * Leveraged Copilot to configure `@page` directives (`/events/{EventId:int}` and `/register/{EventId:int}`) and wire navigation links between the home catalog, details view, and registration page.
   * Generated a custom `<NotFound>` fallback template in `Routes.razor` so invalid URLs display a user-friendly 404 screen instead of crashing.

3. **Debugging & Performance Optimization (Activity 2):**
   * Used Copilot to identify potential `NullReferenceException` edge cases when navigating to non-existent event IDs and added null guards in `EventDetails.razor` and `Register.razor`.
   * Added `@key="ev.Id"` directives in `Home.razor` and unsubscribed event handlers (`IDisposable`) in `MainLayout.razor` and `AttendanceTracker.razor` based on Copilot's optimization recommendations.

4. **Advanced Features — Validation, State Management & Attendance (Activity 3):**
   * Collaborated with Copilot to build the `EditForm` registration flow with Data Annotations validation rules.
   * Scaffolded `UserSessionService` and `AttendanceService` as scoped services with event-driven state notifications (`OnSessionChanged`, `OnAttendanceUpdated`) to keep the navigation bar and `AttendanceTracker` synchronized in real time.

---

## Running Locally

```bash
dotnet restore
dotnet run
```
