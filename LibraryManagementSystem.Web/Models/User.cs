using Microsoft.AspNetCore.Identity;

namespace LibraryManagementSystem.Web.Models
{
    public class User : IdentityUser
    {
        public ICollection<Reservation>? Reservations { get; set; } = new List<Reservation>();
        public ICollection<Notification>? Notifications { get; set; } = new List<Notification>();
    }
}
