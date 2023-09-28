using FluentValidation;
using ImageResizer.Core.Extensions;

namespace ImageResizer.Application.Handlers.Commands.ResizeImage;

public class ResizeImageCommandValidator : AbstractValidator<ResizeImageCommand>
{
    private const string InvalidWidthInformationError = "Width должен быть больше нуля";
    private const string InvalidHeightInformationError = "Height должен быть больше нуля";
    private const string InvalidStreamInformationError = "Файл не задан";

    public ResizeImageCommandValidator()
    {
        RuleFor(x => x.Width)
            .GreaterThan(0).WithState(InvalidWidthInformationError);

        RuleFor(x => x.Height)
            .GreaterThan(0).WithState(InvalidHeightInformationError);

        RuleFor(x => x.Stream)
            .Must(x => x is not null && x.CanRead && x.Length > 0)
            .WithState(InvalidStreamInformationError);
    }
}
