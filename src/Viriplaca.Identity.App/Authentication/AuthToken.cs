namespace Viriplaca.Identity.App.Authentication;

public class AuthToken
{
    public string SubjectId { get; set; } = string.Empty;

    public string DisplayName { get; set; } = string.Empty;

    public DateTimeOffset ExpiredAt { get; set; }
}
