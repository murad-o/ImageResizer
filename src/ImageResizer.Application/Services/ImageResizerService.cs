using ImageResizer.Abstractions.Services;

namespace ImageResizer.Application.Services;

public class ImageResizerService : IImageResizerService
{
    private const int MaxWidth = 1920;
    private const int MaxHeight = 1500;

    public async Task<MemoryStream> ResizeImageAsync(Stream stream, int? width, int? height,
        CancellationToken cancellationToken)
    {
        var outputStream = new MemoryStream();
        using var image = await Image.LoadAsync(stream, cancellationToken);

        var imageFormat = image.Metadata.DecodedImageFormat;

        if (imageFormat is null)
            throw new Exception("Could not identify image format");

        var (newWidth, newHeight) = CalculateSize(image.Size, width, height);

        image.Mutate(i => i.Resize(newWidth, newHeight));
        await image.SaveAsync(outputStream, imageFormat, cancellationToken);

        outputStream.Seek(0, SeekOrigin.Begin);
        return outputStream;
    }

    private static (int newWidth, int newHeight) CalculateSize(Size imageSize, int? width, int? height)
    {
        width = width > MaxWidth ? MaxWidth : width;
        height = height > MaxHeight ? MaxHeight : height;

        int newWidth;
        int newHeight;

        if (width is not null && height is not null)
        {
            newWidth = width.Value;
            newHeight = height.Value;
        }
        else if (width is null && height is null)
        {
            newWidth = imageSize.Width;
            newHeight = imageSize.Height;
        }
        else
        {
            var scaleWidth = (double)(width ?? 0) / imageSize.Width;
            var scaleHeight = (double)(height ?? 0) / imageSize.Height;
            var scale = Math.Max(scaleWidth, scaleHeight);

            newWidth = (int)Math.Round(imageSize.Width * scale);
            newHeight = (int)Math.Round(imageSize.Height * scale);
        }

        return (newWidth, newHeight);
    }
}
