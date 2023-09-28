using ImageResizer.Abstractions.Services;
using ImageResizer.Core.Abstractions.Handlers;

namespace ImageResizer.Application.Handlers.Commands.ResizeImage;

public class ResizeImageCommandHandler : ICommandHandler<ResizeImageCommand, ResizeImageCommandResult>
{
    private readonly IImageResizerService _imageResizerService;

    public ResizeImageCommandHandler(IImageResizerService imageResizerService)
    {
        _imageResizerService = imageResizerService;
    }

    public async Task<ResizeImageCommandResult> Handle(ResizeImageCommand request, CancellationToken cancellationToken)
    {
        var outputStream = await _imageResizerService.ResizeImageAsync(request.Stream,
            request.Width, request.Height, cancellationToken);

        return new ResizeImageCommandResult(outputStream);
    }
}
