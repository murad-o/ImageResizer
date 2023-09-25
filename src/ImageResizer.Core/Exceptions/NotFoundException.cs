namespace ImageResizer.Core.Exceptions;

public class NotFoundException : BaseException
{
    public NotFoundException(string errorMessage, string informationMessage) : base(errorMessage, informationMessage)
    {
    }
}
