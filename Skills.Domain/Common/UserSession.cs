namespace Skills.Domain.Common;

public class UserSession(string username, string? id, bool isAdmin = false)
{
    public Guid? Id { get; set; } = Guid.TryParse(id, out var parsedId) ? parsedId : null;
    public string Username { get; set; } = username;
    public bool IsAdmin { get; set; } = isAdmin;
}