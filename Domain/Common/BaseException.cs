using Domain.Enums;

namespace Domain.Common;

public class BaseException(string message, ExceptionCode code, string? details = null)
    : Exception(message)
{
    public ExceptionCode Code { get; set; } = code;
    public string? Details = details;
}
