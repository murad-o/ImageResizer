using FluentValidation;
using ImageResizer.Core.Abstractions.Models;
using ImageResizer.Core.Models;
using MediatR;
using ValidationException = ImageResizer.Core.Exceptions.ValidationException;

namespace ImageResizer.Core.Behaviors;

public class ValidationBehavior<TRequest, TResult> : IPipelineBehavior<TRequest, TResult>
    where TRequest : IMediatorRequest<TResult>
    where TResult : IMediatorResult
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResult> Handle(TRequest request, RequestHandlerDelegate<TResult> next,
        CancellationToken cancellationToken)
    {
        foreach (var validator in _validators)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var error = validationResult.Errors.FirstOrDefault();

                if (error?.CustomState is not ValidationState validationState)
                {
                    throw new ValidationException(error?.ErrorMessage);
                }

                throw new ValidationException(error.ErrorMessage, validationState.InformationMessage,
                    validationState.StatusCode);
            }
        }

        return await next();
    }
}
