using ImageResizer.Core.Abstractions.Models;

namespace ImageResizer.Application.Handlers.Commands.ResizeImage;

public record ResizeImageCommand
    (Stream Stream, int? Width, int? Height) : ICommand<ResizeImageCommandResult>;
