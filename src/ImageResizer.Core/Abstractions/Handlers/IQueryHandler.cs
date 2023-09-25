using ImageResizer.Core.Abstractions.Models;
using MediatR;

namespace ImageResizer.Core.Abstractions.Handlers;

public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
    where TResult : IMediatorResult
{
}
