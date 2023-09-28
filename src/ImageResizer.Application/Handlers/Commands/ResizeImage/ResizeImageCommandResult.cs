using ImageResizer.Core.Abstractions.Models;

namespace ImageResizer.Application.Handlers.Commands.ResizeImage;

public record ResizeImageCommandResult(Stream Stream) : IMediatorResult;
