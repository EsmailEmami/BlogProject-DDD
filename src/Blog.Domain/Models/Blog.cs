using Blog.Domain.Core.Models;
using Dapper.Contrib.Extensions;

namespace Blog.Domain.Models;

[Table("[Blog].[Blogs]")]
public class Blog : Entity
{
    protected Blog() { }

    public Blog(Guid id, Guid authorId, string blogTitle, string summary, string description, string imageFile, string readTime)
    {
        Id = id;
        AuthorId = authorId;
        BlogTitle = blogTitle;
        Summary = summary;
        Description = description;
        ImageFile = imageFile;
        ReadTime = readTime;
        WrittenAt = DateTime.Now;
    }

    public Guid AuthorId { get; private set; }
    public string BlogTitle { get; private set; }
    public string Summary { get; private set; }
    public string Description { get; private set; }
    public string ImageFile { get; private set; }
    public DateTime WrittenAt { get; private set; }
    public string ReadTime { get; private set; }

    #region Relations

    [Write(false)]
    public User Author { get; protected set; }
    [Write(false)]
    public ICollection<BlogCategory> Categories { get; protected set; }

    #endregion
}