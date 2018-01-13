using System.ComponentModel.DataAnnotations;

namespace Uppgift1Layout.Models
{
    // denna klass hanterar hanteringen av login
    public class LoginModel
    {
        [Display(Name = "Användarnamn")]
        [Required(ErrorMessage = "Du måste skriva in ditt användarnamn")]
        public string Name { get; set; }
        [Display(Name = "Lösenord")]
        [Required(ErrorMessage = "Du måste skriva in ditt lösenord")]
        [UIHint("password")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; } = "/";
    }
}
