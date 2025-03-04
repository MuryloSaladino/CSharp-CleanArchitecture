namespace Skills.Domain.Common;

public class UserSession(string username, string? id)
{
    public string Username { get; set; } = username;
    public Guid? Id { get; set; } = Guid.TryParse(id, out var parsedId) ? parsedId : null;
}