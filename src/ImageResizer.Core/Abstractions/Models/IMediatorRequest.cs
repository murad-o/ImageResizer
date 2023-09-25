using MediatR;

namespace ImageResizer.Core.Abstractions.Models;

public interface IMediatorRequest<TResult> : IRequest<TResult> where TResult : IMediatorResult
{
}

public interface IMediatorRequest : IMediatorRequest<EmptyMediatorResult>
{
}
