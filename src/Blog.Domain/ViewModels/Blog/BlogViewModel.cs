using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blog.Domain.ViewModels.Blog;

public class BlogViewModel
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "The Name is Required")]
    [MinLength(2)]
    [MaxLength(100)]
    [DisplayName("Name")]
    public string BlogTitle { get; set; }
}