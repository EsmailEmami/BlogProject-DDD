namespace Blog.Domain.Queries.User;

public class GetUsersCountQuery : UserQuery<int>
{
    public GetUsersCountQuery(string? search)
    {
        Search = search;
    }

    public override bool IsValid() => true;
}