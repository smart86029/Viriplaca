namespace Viriplaca.Identity.Domain.Users;

public class UserRefreshToken : Entity
{
    private UserRefreshToken()
    {
    }

    internal UserRefreshToken(string refreshToken, DateTimeOffset expireOn, Guid userId)
    {
        if (expireOn < DateTimeOffset.UtcNow)
        {
            throw new DomainException("Expired on must be greater than now");
        }

        UserId = userId;
        RefreshToken = refreshToken;
        ExpireOn = expireOn;
    }

    public Guid UserId { get; private init; }

    public string RefreshToken { get; private init; } = string.Empty;

    public DateTimeOffset ExpireOn { get; private init; }

    public bool IsExpired => DateTimeOffset.UtcNow > ExpireOn;
}
