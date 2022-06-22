using Blog.Domain.Commands.Comment;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Blog.Domain.ViewModels.Comment;
using MediatR;

namespace Blog.Domain.CommandHandlers;

public class CommentCommandHandler : CommandHandler,
    IRequestHandler<RegisterNewCommentCommand, CommentForShowViewModel>
{
    private readonly ICommentRepository _commentRepository;
    public CommentCommandHandler(IMediatorHandler bus, ICommentRepository commentRepository) : base(bus)
    {
        _commentRepository = commentRepository;
    }

    public Task<CommentForShowViewModel> Handle(RegisterNewCommentCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            throw new InvalidOperationException();
        }

        Comment comment = new Comment(Guid.NewGuid(), request.UserId, request.BlogId, request.Title, request.CommentMessage);

        CommentForShowViewModel insertedComment = _commentRepository.Add(comment);
   
        return Task.FromResult(insertedComment);
    }
}