namespace Skills.Domain.Exceptions;

public static class ExceptionMessages
{
    public static class BadRequest
    {
        public const string Default = "Bad request.";
        public const string Format = "The request was not built correctly or contains invalid fields.";
        public const string ValueAlreadyTaken = "You tried creating a resource that requires a unique value that's already in use.";
    }

    public static class Unauthorized
    {
        public const string Default = "Unauthorized.";
        public const string Session = "Invalid user session, you must login first.";
        public const string RefreshToken = "Invalid refresh token provided.";
        public const string Credentials = "Credentials do not match or incorrect password.";
    }

    public static class Forbidden
    {
        public const string Default = "Forbidden.";
        public const string Admin = "You dot not own enough permission. You must be an admin to perform this.";
    }

    public static class NotFound
    {
        public const string Default = "Not Found.";
        public const string Resource = "Resource not found.";
        public const string User = "User not found.";
        public const string Skill = "Skill not found.";
    }

    public static class Conflict
    {
        public const string Default = "Conflict.";
    }

    public static class ImATeapot
    {
        public const string Default = "The server refuses to brew coffee because it is, permanently, a teapot.";
    }

    public static class InternalServerError
    {
        public const string Default = "Internal Server Error.";
    }

    public static class NotImplemented
    {
        public const string Default = "Not Implemented.";
    }

    public static class BadGateway
    {
        public const string Default = "Bad Gateway.";
    }
}