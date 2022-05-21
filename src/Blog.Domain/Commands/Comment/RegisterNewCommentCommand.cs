﻿using Blog.Domain.Validations.Command.Comment;

namespace Blog.Domain.Commands.Comment;

public class RegisterNewCommentCommand : CommentCommand<Guid>
{
    public RegisterNewCommentCommand(Guid userId, Guid blogId, string title, string commentMessage)
    {
        UserId = userId;
        BlogId = blogId;
        Title = title;
        CommentMessage = commentMessage;
    }
    public override bool IsValid()
    {
        ValidationResult = new RegisterNewCommentCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}