using Blog.Domain.Interfaces;
using Blog.Domain.ViewModels.Blog;
using Dapper;
using System.Data;

namespace Blog.Infra.Data.Repository;

public class BlogRepository : Repository<Domain.Models.Blog>, IBlogRepository
{
    public BlogRepository(IDbConnection db) : base(db)
    {
    }

    public bool IsBlogExist(Guid blogId)
    {
        string query = "SELECT (CASE WHEN EXISTS( " +
                       "SELECT NULL " +
                       "FROM [Blog].[Blogs] " +
                       "WHERE [Id] = @BlogId) " +
                       "THEN 1 ELSE 0 END) AS [Value]";

        return Db.QuerySingleOrDefault<bool>(query, new
        {
            blogId
        });
    }

    public UpdateBlogViewModel? GetBlogForUpdate(Guid blogId)
    {
        string query = "SELECT [Id],[AuthorId],[BlogTitle],[Summary],[Description],[ImageFile],[ReadTime] " +
                       "FROM [Blog].[Blogs] " +
                       "WHERE [Id] = @BlogId";

        return Db.QuerySingleOrDefault<UpdateBlogViewModel>(query, new
        {
            blogId
        });
    }

    public List<BlogForShowViewModel> GetAuthorBlogs(Guid authorId)
    {
        string query = "SELECT [Blogs].[Id] AS [BlogId], " +
            "[Blogs].[BlogTitle], " +
            "[Blogs].[Summary], " +
            "[Blogs].[WrittenAt] AS [PostedAt], " +
            "[Blogs].[ImageFile], " +
            "(SELECT COUNT(*) " +
            "FROM [User].[Comments] " +
            "WHERE [BlogId] = [Blogs].[Id]) AS [CommentsCount], " +
            "[Tag].[Tags].[TagName] AS [Tags]" +
            "FROM [Blog].[Blogs] " +
            "INNER JOIN [Tag].[BlogTags] " +
            "ON [Blog].[Blogs].[Id] = [Tag].[BlogTags].[BlogId] " +
            "LEFT JOIN [Tag].[Tags] " +
            "ON [Tag].[BlogTags].[TagId] = [Tag].[Tags].[Id] " +
            "WHERE [Blogs].[AuthorId] = @AuthorId";

        Dictionary<Guid, BlogForShowViewModel> blogDictionary = new Dictionary<Guid, BlogForShowViewModel>();

        List<BlogForShowViewModel> blogs = Db.Query<BlogForShowViewModel, string, BlogForShowViewModel>(query,
            (b, t) =>
        {
            if (!blogDictionary.TryGetValue(b.BlogId, out BlogForShowViewModel? blog))
            {
                blog = b;
                blogDictionary.Add(blog.BlogId, blog);
            }

            blog.Tags.Add(t);
            return blog;
        }, new
        {
            authorId
        }, splitOn: "Tags").Distinct().ToList();

        return blogs;
    }

    public List<BlogForShowViewModel> GetBlogs()
    {
        string query = "SELECT [Blogs].[Id] AS [BlogId], " +
                       "[Blogs].[BlogTitle], " +
                       "[Blogs].[Summary], " +
                       "[Blogs].[WrittenAt] AS [PostedAt], " +
                       "[Blogs].[ImageFile], " +
                       "(SELECT COUNT(*) " +
                       "FROM [User].[Comments] " +
                       "WHERE [BlogId] = [Blogs].[Id]) AS [CommentsCount], " +
                       "[Tag].[Tags].[TagName] AS [Tags]" +
                       "FROM [Blog].[Blogs] " +
                       "INNER JOIN [Tag].[BlogTags] " +
                       "ON [Blog].[Blogs].[Id] = [Tag].[BlogTags].[BlogId] " +
                       "LEFT JOIN [Tag].[Tags] " +
                       "ON [Tag].[BlogTags].[TagId] = [Tag].[Tags].[Id]";

        Dictionary<Guid, BlogForShowViewModel> blogDictionary = new Dictionary<Guid, BlogForShowViewModel>();

        List<BlogForShowViewModel> blogs = Db.Query<BlogForShowViewModel, string, BlogForShowViewModel>(query,
            (b, t) =>
            {
                if (!blogDictionary.TryGetValue(b.BlogId, out BlogForShowViewModel? blog))
                {
                    blog = b;
                    blogDictionary.Add(blog.BlogId, blog);
                }

                blog.Tags.Add(t);
                return blog;
            }, splitOn: "Tags").Distinct().ToList();

        return blogs;
    }
}