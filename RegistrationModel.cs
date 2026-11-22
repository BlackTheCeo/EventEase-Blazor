using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class RegistrationModel
    {
        public int EventId { get; set; }

        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 80 characters.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        [Range(1, 10, ErrorMessage = "Ticket count must be between 1 and 10.")]
        public int Tickets { get; set; } = 1;
    }
}
