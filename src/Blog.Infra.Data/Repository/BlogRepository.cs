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
        // method 1


        //string query = "SELECT [Blogs].[Id], " +
        //               "[Blogs].[AuthorId], " +
        //               "[Blogs].[BlogTitle], " +
        //               "[Blogs].[Summary], " +
        //               "[Blogs].[Description], " +
        //               "[Blogs].[ImageFile], " +
        //               "[Blogs].[ReadTime], " +
        //               "[Tag].[BlogTags].[TagId] AS [Tags], " +
        //               "[Category].[BlogCategories].[CategoryId] AS [Categories] " +
        //               "FROM [Blog].[Blogs] " +
        //               "INNER JOIN [Tag].[BlogTags] ON [Blog].[Blogs].[Id] = [Tag].[BlogTags].[BlogId] " +
        //               "INNER JOIN [Category].[BlogCategories] ON [Blog].[Blogs].[Id] = [Category].[BlogCategories].[BlogId] " +
        //               "WHERE [Blogs].[Id] = @BlogId";

        //Dictionary<Guid, UpdateBlogViewModel> blogDictionary = new Dictionary<Guid, UpdateBlogViewModel>();

        //UpdateBlogViewModel? blog = Db.Query<UpdateBlogViewModel, Guid, Guid, UpdateBlogViewModel>(query,
        //    (main, tag, category) =>
        //    {
        //        if (!blogDictionary.TryGetValue(main.Id, out UpdateBlogViewModel? blogDic))
        //        {
        //            blogDic = main;
        //            blogDictionary.Add(blogDic.Id, blogDic);
        //        }

        //        blogDic.Tags.Add(tag);
        //        blogDic.Categories.Add(category);
        //        return blogDic;
        //    }, new { blogId },
        //    splitOn: "Tags, Categories").FirstOrDefault();

        //blog!.Tags = blog.Tags.Distinct().ToList();
        //blog!.Categories = blog.Categories.Distinct().ToList();

        // ----------------------------------------------------------------------------------------------

        // method 2

        string query = "SELECT [Id], [AuthorId], [BlogTitle], [Summary], [Description], [ImageFile], [ReadTime] " +
                       "FROM [Blog].[Blogs] WHERE [Id] = @BlogId; " +
                       "SELECT [CategoryId] FROM [Category].[BlogCategories] WHERE [BlogId] = @BlogId; " +
                       "SELECT [TagId] FROM [Tag].[BlogTags] WHERE [BlogId] = @BlogId;";

        using var list = Db.QueryMultiple(query, new { blogId });

        UpdateBlogViewModel blog = list.ReadFirstOrDefault<UpdateBlogViewModel>();
        blog.Categories = list.Read<Guid>().ToList();
        blog.Tags = list.Read<Guid>().ToList();

        return blog;
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

    public BlogDetailViewModel GetBlogDetail(Guid blogId)
    {
        string query = "SELECT [Id] AS [BlogId], " +
                       "[BlogTitle], " +
                       "[Summary], " +
                       "[Description], " +
                       "[WrittenAt] AS [PostedAt], " +
                       "[ImageFile], " +
                       "(SELECT COUNT(*) " +
                       "FROM [User].[Comments] " +
                       "WHERE [BlogId] = [Blogs].[Id]) AS [CommentsCount] " +
                       "FROM [Blog].[Blogs] " +
                       "WHERE [Id] = @BlogId";

        return Db.QuerySingleOrDefault<BlogDetailViewModel>(query, new
        {
            blogId
        });
    }
}