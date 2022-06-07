namespace Blog.Domain.ViewModels.User;

public class UpdateUserPasswordViewModel
{
    public Guid UserId { get; set; }
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
    public string ConfirmNewPassword { get; set; }
}