using Blog.Domain.Commands.Tag;

namespace Blog.Domain.Validations.Command.Tag;

public class RegisterNewTagCommandValidation : TagCommandValidation<RegisterNewTagCommand, Guid>
{
    public RegisterNewTagCommandValidation()
    {
        ValidateTagName();
    }
}