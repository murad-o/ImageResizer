using ImageResizer.Core.Exceptions;
using ImageResizer.Core.Models;

namespace ImageResizer.Api.Middlewares;

public class ExceptionHandlingMiddleware : IMiddleware
{
    private const string ContentType = "application/json";
    private const string DefaultInformationMessage = "Что-то пошло не так";

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            var statusCode = GetStatusCode(e);
            var response = GetResponseModel(e, statusCode);

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = ContentType;
            await context.Response.WriteAsJsonAsync(response);
        }
    }

    private static int GetStatusCode(Exception exception)
    {
        return exception switch
        {
            BadRequestException => StatusCodes.Status400BadRequest,
            NotFoundException => StatusCodes.Status404NotFound,
            ValidationException e => e.StatusCode,
            _ => StatusCodes.Status500InternalServerError
        };
    }

    private static ResponseModel<object> GetResponseModel(Exception e, int statusCode)
    {
        return new ResponseModel<object>
        {
            Error = new ResponseModel<object>.ErrorModel
            {
                Message = e.Message,
                Details = e is BaseException baseException ? baseException.InformationMessage : DefaultInformationMessage,
                StatusCode = statusCode
            }
        };
    }
}
