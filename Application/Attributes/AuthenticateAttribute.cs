namespace Application.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class AuthenticateAttribute : Attribute
{
    public bool AdminOnly { get; init; }
}