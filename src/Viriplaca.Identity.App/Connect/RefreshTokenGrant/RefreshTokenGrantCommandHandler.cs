using Viriplaca.Identity.Domain.Clients;
using Viriplaca.Identity.Domain.Grants;
using Viriplaca.Identity.Domain.Grants.RefreshTokens;

namespace Viriplaca.Identity.App.Connect.RefreshTokenGrant;

internal class RefreshTokenGrantCommandHandler(
    IOptions<JwtOptions> jwtOptions,
    IIdentityUnitOfWork unitOfWork,
    IClientRepository clientRepository,
    IRefreshTokenRepository refreshTokenRepository
) : GrantCommandHandler<RefreshTokenGrantCommand>(jwtOptions, unitOfWork, refreshTokenRepository)
{
    private readonly TimeSpan _lifetime = TimeSpan.FromMinutes(5);
    private readonly IIdentityUnitOfWork _identityUnitOfWork = unitOfWork;
    private readonly IClientRepository _clientRepository = clientRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository = refreshTokenRepository;

    public override async Task<GrantResult> Handle(
        RefreshTokenGrantCommand request,
        CancellationToken cancellationToken
    )
    {
        var client = await _clientRepository.GetClientAsync(request.ClientId);
        if (!client.GrantTypes.HasFlag(GrantTypes.RefreshToken))
        {
            return new RefreshTokenGrantResult(GrantError.UnauthorizedClient);
        }

        if (request.RefreshToken.IsNullOrWhiteSpace())
        {
            return new RefreshTokenGrantResult(GrantError.InvalidGrant);
        }

        var refreshToken = await _refreshTokenRepository.GetRefreshTokenAsync(request.RefreshToken);
        if (refreshToken is null)
        {
            return new RefreshTokenGrantResult(GrantError.InvalidGrant);
        }

        if (refreshToken.ClientId != client.Id)
        {
            return new RefreshTokenGrantResult(GrantError.InvalidGrant);
        }

        if (refreshToken.IsExpired)
        {
            return new RefreshTokenGrantResult(GrantError.InvalidGrant);
        }

        if (refreshToken.Scopes.Count == 0)
        {
            return new RefreshTokenGrantResult(GrantError.InvalidRequest);
        }

        await ConsumeAsync(refreshToken);

        var accessToken = GenerateAccessToken(refreshToken);
        var newRefreshToken = await GenerateRefreshTokenAsync(client, refreshToken);
        var result = new RefreshTokenGrantResult
        {
            AccessToken = accessToken,
            RefreshToken = newRefreshToken,
            Lifetime = _lifetime,
        };

        return result;
    }

    private async Task ConsumeAsync(RefreshToken refreshToken)
    {
        refreshToken.Consume();
        _refreshTokenRepository.Update(refreshToken);
        await _identityUnitOfWork.CommitAsync();
    }
}
