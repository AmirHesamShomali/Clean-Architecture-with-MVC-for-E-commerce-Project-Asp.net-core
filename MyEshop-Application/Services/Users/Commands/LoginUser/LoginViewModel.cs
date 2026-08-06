using System.ComponentModel.DataAnnotations;

namespace Services.Users.Commands.LoginUser
{
    public class LoginViewModel
    {
        [EmailAddress(ErrorMessage = "فرمت ایمیل رعایت شود")]
        [Required(ErrorMessage = "لطفا این فیلد پر شود")]
        public string Email { get; set; }
        [Required(ErrorMessage = "لطفا این فیلد پر شود")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "مرابخاطر بسپار")]
        public bool Rememberme { get; set; }
    }
}
