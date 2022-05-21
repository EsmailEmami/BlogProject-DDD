using Blog.Domain.Queries.Comment;
using FluentValidation;

namespace Blog.Domain.Validations.Query.Comment;

public abstract class CommentQueryValidation<TQuery, TResult> : AbstractValidator<TQuery>
    where TQuery : CommentQuery<TResult>
{
    protected void ValidateId()
    {
        RuleFor(c => c.Id)
            .NotEqual(Guid.Empty);
    }

    protected void ValidateUserId()
    {
        RuleFor(c => c.UserId)
            .NotEqual(Guid.Empty);
    }

    protected void ValidateBlogId()
    {
        RuleFor(c => c.BlogId)
            .NotEqual(Guid.Empty);
    }
    }
}