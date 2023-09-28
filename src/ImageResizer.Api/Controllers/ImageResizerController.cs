using ImageResizer.Application.Handlers.Commands.ResizeImage;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ImageResizer.Api.Controllers;

[ApiController]
[Route("image/resizer")]
public class ImageResizerController : ControllerBase
{
    private readonly IMediator _mediator;

    public ImageResizerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> ResizeImageAsync(IFormFile file, int? width, int? height,
        CancellationToken cancellationToken)
    {
        await using var stream = file?.OpenReadStream();

        var command = new ResizeImageCommand(stream, width, height);
        var resizeImageCommandResult = await _mediator.Send(command, cancellationToken);

        return File(resizeImageCommandResult.Stream, file!.ContentType, true);
    }
}
