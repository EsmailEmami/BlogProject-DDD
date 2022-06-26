using Blog.Domain.Common.Exceptions;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Blog.Domain.Queries.Tag;
using Blog.Domain.Queries.User;
using Blog.Domain.ViewModels.Tag;
using Blog.Domain.ViewModels.User;
using MediatR;

namespace Blog.Domain.QueryHandlers;

public class TagQueryHandler : QueryHandler,
    IRequestHandler<GetTagsQuery, List<TagForShowViewModel>>,
    IRequestHandler<GetTagForUpdateQuery, UpdateTagViewModel>,
    IRequestHandler<GetBlogTagsQuery, List<TagForShowViewModel>>
{
    private readonly ITagRepository _tagRepository;
    public TagQueryHandler(IMediatorHandler bus, ITagRepository tagRepository) : base(bus)
    {
        _tagRepository = tagRepository;
    }

    public Task<List<TagForShowViewModel>> Handle(GetTagsQuery request, CancellationToken cancellationToken)
    {
        List<TagForShowViewModel> tags = _tagRepository.GetAllTags();
        return Task.FromResult(tags);
    }

    public Task<UpdateTagViewModel> Handle(GetTagForUpdateQuery request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            throw new InvalidOperationException();
        }

        UpdateTagViewModel? tag = _tagRepository.GetTagForUpdate(request.Id);

        if (tag == null)
        {
            Bus.RaiseEvent(new DomainNotification("blog not found", "تگ مورد نظر یافت نشد"));

            throw new EntityNotFoundException();
        }

        return Task.FromResult(tag);
    }

    public Task<List<TagForShowViewModel>> Handle(GetBlogTagsQuery request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            throw new InvalidOperationException();
        }

        List<TagForShowViewModel> tags = _tagRepository.GetBLogTags(request.BlogId);

        return Task.FromResult(tags);
    }
}