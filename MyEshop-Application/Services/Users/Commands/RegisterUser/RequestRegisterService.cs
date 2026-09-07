using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyEshop_Application.Services.Users.Commands.RegisterUser
{
    public class RequestRegisterService
    {
        [Required(ErrorMessage = "لطفا این فیلد پر شود")]
        [MinLength(2)]
        public string FullName { get; set; }
        [Required(ErrorMessage = "لطفا شماره موبایل را وارد کنید")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "شماره موبایل باید دقیقاً 11 رقم باشد")]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "فرمت شماره موبایل صحیح نیست (مثال: 09120000000)")]
        public string Phone { get; set; }
        public string phone { get; set; }

        [Required(ErrorMessage = "لطفا این فیلد پر شود")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "لطفا این فیلد پر شود")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "پسورد و تکرار آن با هم مطابقت ندارند.")]
        public string Repassword { get; set; }



        public bool IsAdmin { get; set; } = false;

	}
}
