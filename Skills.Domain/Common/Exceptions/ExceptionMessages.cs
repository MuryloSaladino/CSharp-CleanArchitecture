namespace Skills.Domain.Common.Exceptions;

public static class ExceptionMessages
{
    public static class BadRequest
    {
        public const string Default = "Bad request.";
        public const string Format = "The request was not built correctly or contains invalid fields.";
        public const string ValueAlreadyTaken = "You tried creating a resource that requires a unique value that's already in use.";
        public const string NullValue = "A null value was received to create a resource that cannot be null.";
        public const string PasswordLength = "Password length must be at least 8 characters.";
    }

    public static class Unauthorized
    {
        public const string Default = "Unauthorized.";
        public const string Session = "Invalid user session, you must login first.";
        public const string MissingToken = "Missing access token";
        public const string RefreshToken = "Refresh token expired or deleted.";
        public const string TokenPrefix = "Token must be Bearer type.";
        public const string Credentials = "Credentials do not match or incorrect password.";
    }

    public static class Forbidden
    {
        public const string Default = "Forbidden.";
        public const string Admin = "You dot not own enough permission. You must be an admin to perform this.";
        public const string Role = "You dot not own enough permission. You need a higher role to perform this.";
        public const string NotOwnUser = "You must reference a object owned by you to perform this.";
        public const string NotOwnUserNorAdmin = "You must reference a object owned by you or be an admin to perform this.";
    }

    public static class NotFound
    {
        public const string Default = "Not Found.";
        public const string Resource = "Resource not found.";
        public const string User = "User not found.";
        public const string Category = "Category not found.";
        public const string Delivery = "Delivery not found.";
        public const string Department = "Department not found.";
        public const string Item = "Item not found.";
        public const string Image = "Image not found.";
        public const string Order = "Order not found.";
    }

    public static class Conflict
    {
        public const string Default = "Conflict.";
        public const string ResourceState = "The request could not be completed due to a conflict with the current state of the resource.";
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
        public const string Storage = "Our storage service failed.";
    }
}