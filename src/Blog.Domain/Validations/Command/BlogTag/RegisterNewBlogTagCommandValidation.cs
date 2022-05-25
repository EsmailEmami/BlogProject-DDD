using Blog.Domain.Commands.BlogTag;
using Blog.Domain.Commands.Tag;

namespace Blog.Domain.Validations.Command.BlogTag;

public class RegisterNewBlogTagCommandValidation : BlogTagCommandValidation<RegisterNewBlogTagCommand>
{
    public RegisterNewBlogTagCommandValidation()
    {
        ValidateBlogId();
        ValidateTagId();
    }
}