using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Web.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string ISBN { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int AuthorId { get; set; }

        public Author? Author { get; set; }

        public int Quantity { get; set; }

        public int AvailableQuantity { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}
