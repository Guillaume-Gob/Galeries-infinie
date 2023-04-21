using System.ComponentModel.DataAnnotations;

namespace GaleriesInfinieAPI.Models
{
    public class RegisterDTO
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public string PasswordConfirm { get; set; } = null!;







    }
}
