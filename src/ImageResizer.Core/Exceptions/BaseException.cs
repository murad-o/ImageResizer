namespace ImageResizer.Core.Exceptions;

public class BaseException : Exception
{
    public BaseException(string errorMessage, string informationMessage) : base(errorMessage)
    {
        InformationMessage = informationMessage;
    }

    public string InformationMessage { get; set; }
}
