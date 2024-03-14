using System.ComponentModel.DataAnnotations;

namespace HotelListing.Api.Data.Users
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "your password is limited between {2} to {1} charaters")]
        public string Password { get; set; }
    }
}