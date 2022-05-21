using Blog.Domain.Commands.Comment;
using FluentValidation;

namespace Blog.Domain.Validations.Command.Comment;

public abstract class CommentCommandValidation<TCommand, TResult> : AbstractValidator<TCommand> where TCommand : CommentCommand<TResult>
{
    protected void ValidateTitle()
    {
        RuleFor(c => c.Title)
            .NotEmpty().WithMessage("لطفا عنوان بازخورد را وارد کنید")
            .Length(5, 150).WithMessage("عنوان وارد شده باید بین 5 تا 150 کاراکتر باشد")
            .Must(x => x.Split(" ").ToList().Count > 2)
            .WithMessage("عنوان وارد شده حداقل باید شامل 4 بخش باشد");
    }

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

    protected void ValidateMessage()
    {
        RuleFor(c => c.CommentMessage)
            .NotEmpty().WithMessage("لطفا متن بازخورد را وارد کنید")
            .Length(10, 1000).WithMessage("متن بازخورد وارد شده باید بین 10 تا 1000 کاراکتر باشد");
    }

}