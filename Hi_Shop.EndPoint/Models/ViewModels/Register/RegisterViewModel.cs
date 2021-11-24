using System.ComponentModel.DataAnnotations;

namespace Hi_Shop.EndPoint.Models.ViewModels.Register
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "نام و نام خانوادگی را وارد کنید")]
        [Display(Name = "نام و نام خانوادگی")]
        [MaxLength(100, ErrorMessage = "نام و نام خانوادگی نباید بیشتر از 100 کاراکتر باشد")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "ایمیل را وارد نمایید")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "رمز عبور را وارد نمایید")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Required(ErrorMessage = "تکرار رمز عبور را وارد نمایید")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "رمز عبور و تکرار آن باید برابر باشند")]
        [Display(Name = "تکرار رمز عبور")]
        public string RePassword { get; set; }

        public string PhoneNumber { get; set; }
    }
}
