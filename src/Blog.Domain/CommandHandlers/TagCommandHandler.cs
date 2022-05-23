using Blog.Domain.Commands.Tag;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using MediatR;

namespace Blog.Domain.CommandHandlers;

public class TagCommandHandler : CommandHandler,
    IRequestHandler<RegisterNewTagCommand, Guid>
{
    private readonly ITagRepository _tagRepository;
    public TagCommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications, ITagRepository tagRepository) : base(uow, bus, notifications)
    {
        _tagRepository = tagRepository;
    }

    public Task<Guid> Handle(RegisterNewTagCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(Guid.Empty);
        }

        Tag tag = new Tag(Guid.NewGuid(), request.TagName);
        _tagRepository.Add(tag);
        Commit();
        return Task.FromResult(tag.Id);
    }
}