namespace ImageResizer.Core.Models;

public class ValidationState
{
    private const int DefaultStatusCode = 400;

    public ValidationState(string informationMessage, int statusCode = DefaultStatusCode)
    {
        StatusCode = statusCode;
        InformationMessage = informationMessage;
    }

    public int StatusCode { get; }

    public string InformationMessage { get; }
}
