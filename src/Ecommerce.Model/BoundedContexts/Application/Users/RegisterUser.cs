using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.Model
{
    public class RegisterUser
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
