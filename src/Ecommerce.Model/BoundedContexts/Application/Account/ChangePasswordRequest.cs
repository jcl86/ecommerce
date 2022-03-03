using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.Model
{
    public class ChangePasswordRequest
    {
        [Required]
        public string CurrentPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}
