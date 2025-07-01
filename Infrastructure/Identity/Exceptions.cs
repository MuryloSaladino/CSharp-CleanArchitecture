using Domain.Common;
using Domain.Enums;

namespace Infrastructure.Identity;

public class InvalidSessionException() 
    : BaseException("Invalid session, login needed.", ExceptionCode.Unauthorized);