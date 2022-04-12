using Blog.Domain.Interfaces;
using Blog.Infra.Data.Context;

namespace Blog.Infra.Data.Repository;

public class BlogRepository:Repository<Domain.Models.Blog>,IBlogRepository
{
    public BlogRepository(ApplicationDbContext context) : base(context)
    {
    }
}