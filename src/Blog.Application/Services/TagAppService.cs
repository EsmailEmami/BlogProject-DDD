using AutoMapper;
using Blog.Application.Interfaces;
using Blog.Domain.Commands.Tag;
using Blog.Domain.Core.Bus;
using Blog.Domain.Queries.Tag;
using Blog.Domain.ViewModels.Tag;

namespace Blog.Application.Services;

public class TagAppService : ITagAppService
{
    private readonly IMapper _mapper;
    private readonly IMediatorHandler _bus;

    public TagAppService(IMapper mapper, IMediatorHandler bus)
    {
        _mapper = mapper;
        _bus = bus;
    }

    public async Task<TagForShowViewModel> AddTagAsync(AddTagViewModel tag)
    {
        RegisterNewTagCommand command = _mapper.Map<RegisterNewTagCommand>(tag);
        return await _bus.SendCommand<RegisterNewTagCommand, TagForShowViewModel>(command);
    }

    public void UpdateTag(UpdateTagViewModel tag)
    {
        UpdateTagCommand command = _mapper.Map<UpdateTagCommand>(tag);
        _bus.SendCommand<UpdateTagCommand, bool>(command);
    }

    public void DeleteTag(Guid tagId)
    {
        RemoveTagCommand command = _mapper.Map<RemoveTagCommand>(tagId);
        _bus.SendCommand<RemoveTagCommand, bool>(command);
    }

    public async Task<List<TagForShowViewModel>> GetAllTagsAsync()
    {
        GetTagsQuery query = new GetTagsQuery();
        return await _bus.SendQuery<GetTagsQuery, List<TagForShowViewModel>>(query);
    }

    public async Task<UpdateTagViewModel?> GetTagForUpdateAsync(Guid tagId)
    {
        GetTagForUpdateQuery query = new GetTagForUpdateQuery(tagId);
        return await _bus.SendQuery<GetTagForUpdateQuery, UpdateTagViewModel>(query);
    }

    public async Task<List<TagForShowViewModel>> GetBlogTags(Guid blogId)
    {
        GetBlogTagsQuery query = new GetBlogTagsQuery(blogId);
        return await _bus.SendQuery<GetBlogTagsQuery, List<TagForShowViewModel>>(query);
    }

    public void Dispose() => GC.SuppressFinalize(this);
}