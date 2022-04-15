using System.ComponentModel.DataAnnotations;

namespace Blog.Application.ViewModels.User;

public class RegisterViewModel
{
    [Key]
    public Guid Id { get; set; }

    [Display(Name = "نام")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MinLength(3, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    public string FirstName { get; set; }

    [Display(Name = "نام و نام خانوادگی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MinLength(3, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    public string LastName { get; set; }

    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    public string Email { get; set; }

    [Display(Name = "رمز عبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d#?!@$%^&*-]{6,50}$", ErrorMessage = "کلمه عبور باید شامل حرف و عدد باشد")]
    public string Password { get; set; }

    [Display(Name = "تکرار رمز عبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    [Compare("Password", ErrorMessage = "رمز عبور وارد شده مطابقت ندارد.")]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d#?!@$%^&*-]{6,50}$", ErrorMessage = "کلمه عبور باید شامل حرف و عدد باشد")]
    public string ConfirmPassword { get; set; }
}