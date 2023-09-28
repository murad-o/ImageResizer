namespace ImageResizer.Abstractions.Services;

public interface IImageResizerService
{
    Task<MemoryStream> ResizeImageAsync(Stream stream, int? width, int? height, CancellationToken cancellationToken);
}
