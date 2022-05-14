using Blog.Domain.Validations.Command.Blog;

namespace Blog.Domain.Commands.Blog;

public class RemoveBlogCommand : BlogCommand<bool>
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