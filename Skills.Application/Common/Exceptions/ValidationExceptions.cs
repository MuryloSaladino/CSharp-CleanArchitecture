using Skills.Domain.Common;
using Skills.Domain.Enums;

namespace Skills.Application.Common.Exceptions;

public class RequestValidationException(Dictionary<string, string> errors)
    : BaseException("One or more validation errors occurred.", ExceptionCode.BadRequest)
{
    public Dictionary<string, string> Errors { get; } = errors;
}
