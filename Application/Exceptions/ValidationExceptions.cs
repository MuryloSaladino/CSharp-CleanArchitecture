using Domain.Common;
using Domain.Enums;

namespace Application.Exceptions;

public class RequestValidationException(string details)
    : BaseException("One or more validation errors occurred.", ExceptionCode.BadRequest, details);
