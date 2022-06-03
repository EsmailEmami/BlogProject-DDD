using Blog.Domain.Commands.Comment;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using MediatR;

namespace Blog.Domain.CommandHandlers;

public class CommentCommandHandler : CommandHandler,
    IRequestHandler<RegisterNewCommentCommand, Guid>
{
    private readonly ICommentRepository _commentRepository;
    public CommentCommandHandler(IMediatorHandler bus, ICommentRepository commentRepository) : base(bus)
    {
        _commentRepository = commentRepository;
    }

    public Task<Guid> Handle(RegisterNewCommentCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(Guid.Empty);
        }

        Comment comment = new Comment(Guid.NewGuid(), request.UserId, request.BlogId, request.Title, request.CommentMessage);

        _commentRepository.Add(comment);
   
        return Task.FromResult(comment.Id);
    }
}