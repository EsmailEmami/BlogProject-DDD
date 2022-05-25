using Blog.Domain.Commands.Tag;

namespace Blog.Domain.Validations.Command.Tag;

public class RemoveTagCommandValidation : TagCommandValidation<RemoveTagCommand, bool>
{
    public RemoveTagCommandValidation()
    {
        ValidateId();
    }
}