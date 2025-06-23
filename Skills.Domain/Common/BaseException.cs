using Skills.Domain.Enums;

namespace Skills.Domain.Common;

public class BaseException(string message, ExceptionCode statusCode, string? details = null) 
    : Exception(message)
{
    public ExceptionCode StatusCode { get; set; } = statusCode;
    public string? Details = details;
}
