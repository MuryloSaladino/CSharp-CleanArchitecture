namespace Skills.API.Middlewares.Authenticate;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
public class AuthenticateAttribute : Attribute { }