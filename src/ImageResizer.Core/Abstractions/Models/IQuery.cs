namespace ImageResizer.Core.Abstractions.Models;

public interface IQuery<TResult> : IMediatorRequest<TResult> where TResult : IMediatorResult
{
}

public interface IQuery : IMediatorRequest
{
}
