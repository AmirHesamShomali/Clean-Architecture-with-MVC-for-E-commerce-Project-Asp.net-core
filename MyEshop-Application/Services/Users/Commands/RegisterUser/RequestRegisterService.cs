using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyEshop_Application.Services.Users.Commands.RegisterUser
{
    public class RequestRegisterService
    {
        [Required(ErrorMessage = "لطفا این فیلد پر شود")]
        [MinLength(2)]
        public string FullName { get; set; }

        [EmailAddress(ErrorMessage = "فرمت ایمیل رعایت شود")]
        [Required(ErrorMessage = "لطفا این فیلد پر شود")]
        public string Email { get; set; }

        [Required(ErrorMessage = "لطفا این فیلد پر شود")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "لطفا این فیلد پر شود")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "پسورد و تکرار آن با هم مطابقت ندارند.")]
        public string Repassword { get; set; }
    }
}
