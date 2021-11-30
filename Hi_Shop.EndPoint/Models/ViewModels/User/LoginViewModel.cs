using System.ComponentModel.DataAnnotations;

namespace Hi_Shop.EndPoint.Models.ViewModels.User
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "ایمیل را وارد نمایید")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "رمز عبور را وارد نمایید")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool IsPersistent { get; set; } = false;

        public string ReturnUrl { get; set; }
    }
}
