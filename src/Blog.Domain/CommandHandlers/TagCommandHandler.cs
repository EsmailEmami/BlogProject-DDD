using Blog.Domain.Commands.Tag;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using MediatR;
using System.Data.SqlClient;
using Blog.Domain.ViewModels.Tag;

namespace Blog.Domain.CommandHandlers;

public class TagCommandHandler : CommandHandler,
    IRequestHandler<RegisterNewTagCommand, TagForShowViewModel>,
    IRequestHandler<UpdateTagCommand, bool>,
    IRequestHandler<RemoveTagCommand, bool>
{
    private readonly ITagRepository _tagRepository;
    public TagCommandHandler(IMediatorHandler bus, ITagRepository tagRepository) : base(bus)
    {
        _tagRepository = tagRepository;
    }

    public Task<TagForShowViewModel> Handle(RegisterNewTagCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            throw new InvalidOperationException();
        }

        Tag tag = new Tag(Guid.NewGuid(), request.TagName);

        try
        {
            _tagRepository.Add(tag);
        }
        catch (SqlException error)
        {
            if (error.Number == 2601)
            {
                Bus.RaiseEvent(new DomainNotification("index errror from SQL", "نام تگ وارد شده ثبت شده است"));
            }

            throw;
        }

        return Task.FromResult(new TagForShowViewModel { TagId = tag.Id, TagName = tag.TagName });
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
        return Task.FromResult(true);
    }
}