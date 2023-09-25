namespace ImageResizer.Core.Abstractions.Models;

public interface ICommand<TResponse> : IMediatorRequest<TResponse> where TResponse : IMediatorResult
{
}

public interface ICommand : IMediatorRequest
{
}
