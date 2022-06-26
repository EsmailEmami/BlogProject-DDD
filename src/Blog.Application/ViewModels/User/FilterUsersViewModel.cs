using Blog.Domain.ViewModels.User;

namespace Blog.Application.ViewModels.User;

public class FilterUsersViewModel : BasePaging
{
    public FilterUsersViewModel(string? search)
    {
        Search = search;
    }

    public string? Search { get; }

    public List<UserForShowViewModel> Users { get; private set; } = new();

    public FilterUsersViewModel SetPaging(BasePaging paging)
    {
       SetPage(paging);
       return this;
    }

    public FilterUsersViewModel SetUsers(List<UserForShowViewModel> users)
    {
        Users = users;
        return this;
    }
}