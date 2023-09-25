namespace ImageResizer.Core.Models;

public class ResponseModel<T>
{
    public T Data { get; set; }

    public ErrorModel Error { get; set; }

    public class ErrorModel
    {
        public string Message { get; set; }

        public string Details { get; set; }

        public int StatusCode { get; set; }
    }
}
