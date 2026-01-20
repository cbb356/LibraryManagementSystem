using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Web.Models
{
    public enum ReservationStatus
    {
        Active,
        Completed,
        Cancelled
    }

    public class Reservation
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public Book? Book { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;
        public User User { get; set; } = null!;

        public DateTime ReservationDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public ReservationStatus Status { get; set; }
    }
}
