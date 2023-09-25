namespace ImageResizer.Core.Exceptions;

public class BadRequestException : BaseException
{
    public BadRequestException(string errorMessage, string informationMessage) : base(errorMessage, informationMessage)
    {
    }
}
