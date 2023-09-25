namespace ImageResizer.Core.Exceptions;

public class ValidationException : BaseException
{
    public ValidationException(string errorMessage) : base(errorMessage, null)
    {
    }

    public ValidationException(string errorMessage, string informationMessage, int statusCode) : base(errorMessage, informationMessage)
    {
        InformationMessage = informationMessage;
        StatusCode = statusCode;
    }

    public int StatusCode { get; set; }
}
