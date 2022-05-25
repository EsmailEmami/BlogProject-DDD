using Blog.Domain.Commands.Tag;

namespace Blog.Domain.Validations.Command.Tag;

public class UpdateTagCommandValidation : TagCommandValidation<UpdateTagCommand, bool>
{
    public UpdateTagCommandValidation()
    {
        ValidateId();
        ValidateTagName();
    }
}