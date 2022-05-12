using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blog.Domain.ViewModels.Blog;

public class BlogViewModel
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid AuthorId { get; set; }

    [Required(ErrorMessage = "The Name is Required")]
    [MinLength(2)]
    [MaxLength(100)]
    [DisplayName("Name")]
    public string BlogTitle { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public string Base64Image { get; set; }
    public string ImageFile { get; set; }
    public DateTime WrittenAt { get; set; }
    public string ReadTime { get; set; }
}