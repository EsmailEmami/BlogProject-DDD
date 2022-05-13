using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blog.Domain.ViewModels.Blog;

public class AddBlogViewModel
{
    public Guid AuthorId { get; set; } = Guid.NewGuid();
    public string BlogTitle { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public string ImageFile { get; set; }
    public string ReadTime { get; set; }
}