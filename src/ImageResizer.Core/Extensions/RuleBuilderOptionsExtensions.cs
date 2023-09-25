using FluentValidation;
using ImageResizer.Core.Models;

namespace ImageResizer.Core.Extensions;

public static class RuleBuilderOptionsExtensions
{
    public static void WithState<T, TProperty>(this IRuleBuilderOptions<T, TProperty> options,
        string informationMessage)
    {
        options.WithState(_ => new ValidationState(informationMessage));
    }
}
