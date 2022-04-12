using Blog.Domain.Validations.Blog;

namespace Blog.Domain.Commands.Blog;

public class RemoveBlogCommand : BlogCommand
{
    public RemoveBlogCommand(Guid id)
    {
        Id = id;
    }

    public override bool IsValid()
    {
        ValidationResult = new RemoveBlogCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}