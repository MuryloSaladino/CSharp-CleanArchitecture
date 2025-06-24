using Skills.Domain.Common;
using Skills.Domain.Enums;

namespace Skills.Application.Pipeline.Authentication;

public class AuthenticationException(string message)
    : BaseException("Unauthorized: " + message, ExceptionCode.Unauthorized);
    
public class NotAdminException()
    : BaseException("Forbidden access: you need admin privileges.", ExceptionCode.Forbidden);
