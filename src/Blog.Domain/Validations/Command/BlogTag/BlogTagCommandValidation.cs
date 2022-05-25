using Blog.Domain.Commands.Blog;
using Blog.Domain.Commands.BlogTag;
using FluentValidation;

namespace Blog.Domain.Validations.Command.BlogTag;

public abstract class BlogTagCommandValidation<TCommand> : AbstractValidator<TCommand>
    where TCommand : BlogTagCommand
{
    protected void ValidateBlogId()
    {
        RuleFor(c => c.BlogId)
            .NotEqual(Guid.Empty);
    }
    protected void ValidateTagId()
    {
        RuleFor(c => c.TagId)
            .NotEqual(Guid.Empty);
    }
    protected void ValidateId()
    {
        RuleFor(c => c.Id)
            .NotEqual(Guid.Empty);
    }
}