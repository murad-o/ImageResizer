using ImageResizer.Core.Abstractions.Models;
using MediatR;

namespace ImageResizer.Core.Abstractions.Handlers;

public interface ICommandHandler<TCommand, TResult> : IRequestHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>
    where TResult : IMediatorResult
{
}
