using System.ComponentModel.DataAnnotations;

namespace Blog.Domain.ViewModels.Category;

public class UpdateCategoryViewModel
{
    [Required]
    public Guid CategoryId { get; set; }

    [Display(Name = "عنوان دسته بندی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MinLength(3, ErrorMessage = "{0} نمی تواند کمتر از {1} کاراکتر باشد .")]
    [MaxLength(20, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
    public string CategoryTitle { get; set; }
}