using System.ComponentModel.DataAnnotations;

namespace RealtyWeb_Client.Models
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Слишком длинное имя")]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
