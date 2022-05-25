using Blog.Domain.Commands.Tag;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Events.Blog;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using MediatR;

namespace Blog.Domain.CommandHandlers;

public class TagCommandHandler : CommandHandler,
    IRequestHandler<RegisterNewTagCommand, Guid>,
    IRequestHandler<UpdateTagCommand, bool>,
    IRequestHandler<RemoveTagCommand, bool>
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

    public Task<bool> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(false);
        }

        Tag tag = new Tag(request.Id, request.TagName);
        Tag? existingTag = _tagRepository.GetById(request.Id);

        if (existingTag == null)
        {
            Bus.RaiseEvent(new DomainNotification("tag not found", "تگ مورد نظر یافت نشد"));
            return Task.FromResult(false);
        }

        if (existingTag.Id != tag.Id)
        {
            if (!existingTag.Equals(tag))
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "کاربر مورد نظر در سیستم موجود است."));
                return Task.FromResult(false);
            }
        }

        _tagRepository.Update(tag);
        Commit();
        return Task.FromResult(true);
    }

    public Task<bool> Handle(RemoveTagCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(false);
        }

        Tag? tag = _tagRepository.GetById(request.Id);

        if (tag == null)
        {
            Bus.RaiseEvent(new DomainNotification("tag not found", "تگ مورد نظر یافت نشد"));
            return Task.FromResult(false);
        }

        _tagRepository.Delete(tag);
        Commit();
        return Task.FromResult(true);
    }
}