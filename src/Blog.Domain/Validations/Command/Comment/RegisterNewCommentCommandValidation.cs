using Blog.Domain.Commands.Comment;

namespace Blog.Domain.Validations.Command.Comment;

public class RegisterNewCommentCommandValidation : CommentCommandValidation<RegisterNewCommentCommand, Guid>
{
    public RegisterNewCommentCommandValidation()
    {
        ValidateUserId();
        ValidateBlogId();
        ValidateTitle();
        ValidateMessage();
    }
}