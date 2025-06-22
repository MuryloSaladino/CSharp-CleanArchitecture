namespace Skills.Domain.Exceptions;

public class AppException(ExceptionCode statusCode, string message, string? details = null) : Exception(message)
{
    public ExceptionCode StatusCode { get; set; } = statusCode;
    public string? Details = details;
}