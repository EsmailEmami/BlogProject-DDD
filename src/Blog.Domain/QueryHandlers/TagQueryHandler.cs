using Blog.Domain.Core.Bus;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Blog.Domain.Queries.Tag;
using MediatR;

namespace Blog.Domain.QueryHandlers;

public class TagQueryHandler : QueryHandler,
    IRequestHandler<GetTagsQuery, List<Tag>>
{
    private readonly ITagRepository _tagRepository;
    public TagQueryHandler(IMediatorHandler bus, ITagRepository tagRepository) : base(bus)
    {
        _tagRepository = tagRepository;
    }

    public Task<List<Tag>> Handle(GetTagsQuery request, CancellationToken cancellationToken)
    {
        List<Tag> tags = _tagRepository.GetAll();
        return Task.FromResult(tags);
    }
}