namespace Blog.Domain.Queries.Role;

public class GetAllRolesQuery : RoleQuery<List<Models.Role>>
{
    public GetAllRolesQuery()
    {
    }

    public override bool IsValid() => true;
}