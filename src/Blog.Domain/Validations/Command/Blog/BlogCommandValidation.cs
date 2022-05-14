using Blog.Domain.Commands.Blog;
using FluentValidation;

namespace Blog.Domain.Validations.Command.Blog;

public abstract class BlogCommandValidation<TCommand, TResult> : AbstractValidator<TCommand> 
    where TCommand : BlogCommand<TResult>
{
    protected void ValidateTitle()
    {
        RuleFor(c => c.BlogTitle)
            .NotEmpty().WithMessage("لطفا عنوان مقاله را وارد کنید")
            .Length(5, 150).WithMessage("عنوان وارد شده باید بین 5 تا 150 کاراکتر باشد")
            .Must(x => x.Split(" ").ToList().Count > 1)
            .WithMessage("عنوان وارد شده حداقل باید شامل 3 بخش باشد");
    }

    protected void ValidateId()
    {
        RuleFor(c => c.Id)
            .NotEqual(Guid.Empty);
    }

    protected void ValidateAuthorId()
    {
        RuleFor(c => c.AuthorId)
            .NotEqual(Guid.Empty);
    }

    protected void ValidateSummary()
    {
        RuleFor(c => c.Summary)
            .NotEmpty().WithMessage("لطفا خلاصه مقاله را وارد کنید")
            .Length(50, 1000).WithMessage("خلاصه مقاله وارد شده باید بین 50 تا 1000 کاراکتر باشد");
    }

    protected void ValidateDescription()
    {
        RuleFor(c => c.Description)
            .NotEmpty().WithMessage("لطفا متن مقاله را وارد کنید")
            .MinimumLength(2000).WithMessage("متن مقاله وارد شده باید حداقل 2000 کاراکتر باشد");
    }

    protected void ValidateImageFile()
    {
        RuleFor(c => c.ImageFile)
            .NotEmpty().WithMessage("لطفا تصویر مقاله را وارد کنید")
            .WithMessage("تصویر ارسالی باید یکی از فرمت های PNG,JPG,JPEG باشد");
    }

    protected void ValidateReadTime()
    {
        RuleFor(c => c.ReadTime)
            .NotEmpty().WithMessage("لطفا مدت زمان خواندن مقاله را وارد کنید")
            .MaximumLength(10).WithMessage("مدت زمان خواندن مقاله وارد شده باید حداکثر 10 کاراکتر باشد");
    }

}