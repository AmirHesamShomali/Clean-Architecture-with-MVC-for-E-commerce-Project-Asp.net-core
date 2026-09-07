using System.ComponentModel.DataAnnotations;

namespace Services.Users.Commands.LoginUser
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "لطفا شماره موبایل را وارد کنید")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "شماره موبایل باید دقیقاً 11 رقم باشد")]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "فرمت شماره موبایل صحیح نیست (مثال: 09120000000)")]
        public string Phone { get; set; }
        public string phone { get; set; }
        [Required(ErrorMessage = "لطفا این فیلد پر شود")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "مرابخاطر بسپار")]
        public bool Rememberme { get; set; }
    }
}
