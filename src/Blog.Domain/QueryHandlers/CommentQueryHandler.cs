using Blog.Domain.Core.Bus;
using Blog.Domain.Interfaces;
using Blog.Domain.Queries.Comment;
using Blog.Domain.ViewModels.Comment;
using MediatR;

namespace Blog.Domain.QueryHandlers;

public class CommentQueryHandler : QueryHandler,
    IRequestHandler<GetBlogCommentsQuery, List<CommentForShowViewModel>>
{
    private readonly ICommentRepository _commentRepository;
    public CommentQueryHandler(IMediatorHandler bus, ICommentRepository commentRepository) : base(bus)
    {
        _commentRepository = commentRepository;
    }

    public Task<List<CommentForShowViewModel>> Handle(GetBlogCommentsQuery request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            throw new InvalidOperationException();
        }

        List<CommentForShowViewModel> comments = _commentRepository.GetBlogComments(request.BlogId);
        return Task.FromResult(comments);
    }
}