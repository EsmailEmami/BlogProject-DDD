using Blog.Domain.Commands.BlogTag;

namespace Blog.Domain.Validations.Command.BlogTag;

public class RemoveBlogTagCommandValidation : BlogTagCommandValidation<RemoveBlogTagCommand>
{
    public RemoveBlogTagCommandValidation()
    {
        ValidateId();
    }
}