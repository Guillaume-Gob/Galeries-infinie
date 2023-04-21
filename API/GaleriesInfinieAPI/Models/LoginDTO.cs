using System.ComponentModel.DataAnnotations;

namespace GaleriesInfinieAPI.Models
{
    public class LoginDTO
    {
        [Required]
        public String Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;   

        



    }
}
