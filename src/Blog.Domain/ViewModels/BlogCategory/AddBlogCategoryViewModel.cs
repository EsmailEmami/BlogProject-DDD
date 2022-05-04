using System.ComponentModel.DataAnnotations;

namespace Blog.Domain.ViewModels.BlogCategory;

public class AddBlogCategoryViewModel
{
    [Required]
    public Guid BlogId { get; set; }
    [Required]
    public Guid CategoryId { get; set; }
}