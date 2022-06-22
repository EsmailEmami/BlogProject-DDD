using Blog.Domain.Commands.Comment;
using Blog.Domain.ViewModels.Comment;

namespace Blog.Domain.Validations.Command.Comment;

public class RegisterNewCommentCommandValidation : CommentCommandValidation<RegisterNewCommentCommand, CommentForShowViewModel>
{
    public RegisterNewCommentCommandValidation()
    {
        ValidateUserId();
        ValidateBlogId();
        ValidateTitle();
        ValidateMessage();
    }
}