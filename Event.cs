using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Event title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Event date is required.")]
        public DateTime Date { get; set; } = DateTime.Today.AddDays(7);

        [Required(ErrorMessage = "Event location is required.")]
        [StringLength(150, ErrorMessage = "Location cannot exceed 150 characters.")]
        public string Location { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; } = string.Empty;

        public int Capacity { get; set; } = 100;
    }
}
