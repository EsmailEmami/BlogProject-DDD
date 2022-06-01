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

    public void AddTag(AddTagViewModel tag)
    {
        RegisterNewTagCommand command = _mapper.Map<RegisterNewTagCommand>(tag);
        _bus.SendCommand<RegisterNewTagCommand, Guid>(command);
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
        try
        {
            return await _bus.SendQuery<GetTagForUpdateQuery, UpdateTagViewModel>(query);
        }
        catch
        {
            return null;
        }
    }

    public void Dispose() => GC.SuppressFinalize(this);
}