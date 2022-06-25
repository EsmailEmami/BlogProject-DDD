using Blog.Domain.Commands.Tag;
using Blog.Domain.ViewModels.Tag;

namespace Blog.Domain.Validations.Command.Tag;

public class RegisterNewTagCommandValidation : TagCommandValidation<RegisterNewTagCommand, TagForShowViewModel>
{
    public RegisterNewTagCommandValidation()
    {
        ValidateTagName();
    }
}