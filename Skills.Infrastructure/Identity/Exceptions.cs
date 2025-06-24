using Skills.Domain.Common;
using Skills.Domain.Enums;

namespace Skills.Infrastructure.Identity;

public class InvalidSessionException() 
    : BaseException("Invalid session, login needed.", ExceptionCode.Unauthorized);