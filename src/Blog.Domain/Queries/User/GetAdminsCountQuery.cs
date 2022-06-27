namespace Blog.Domain.Queries.User;

public class GetAdminsCountQuery : UserQuery<int>
{
    public GetAdminsCountQuery(string? search)
    {
        Search = search;
    }

    public override bool IsValid() => true;
}